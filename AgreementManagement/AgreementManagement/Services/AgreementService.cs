using AgreementManagement.Application.Interfaces.Repositories;
using AgreementManagement.Domain.Entities;
using AgreementManagement.Domain.Entities.Interfaces;
using AgreementManagement.Interfaces.Services;
using AgreementManagement.Models;
using AgreementManagement.Persistance;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AgreementManagement.Services
{
	public class AgreementService : BaseService, IAgreementService
	{
		private IAgreementRepository _agreementRepository;
		private IProductRepository _productRepository;

		public AgreementService(
			IAgreementRepository agreementRepository,
			IProductRepository productRepository,
			IMapper mapper)
			: base(mapper)
		{
			_agreementRepository = agreementRepository;
			_productRepository = productRepository;
		}

		public async Task CreateAgreementAsync(Guid userId, AgreementCreationViewModel model)
		{
			var agreement = Mapper.Map<Agreement>(model);

			var currentProduct = await _productRepository.GetAsync(model.ProductId);

			SetCreator(agreement, userId);

			await _agreementRepository.AddAsync(agreement);
		}

		public async Task UpdateAgreementAsync(Guid userId, AgreementUpdateViewModel model)
		{
			var agreement = Mapper.Map<Agreement>(model);
			var curremtProduct = await _productRepository.GetAsync(model.ProductId);

			var creator = agreement as ICreator;
			if (creator == null)
			{
				throw new InvalidCastException();
			}

			SetCreator(agreement, userId);

			await _agreementRepository.UpdateAsync(agreement);
		}

		public async Task RemoveAgreementAsync(int agreementId)
		{
			var agreement = await _agreementRepository.GetAsync(agreementId);

			var deletable = agreement as IDeletable;
			if (deletable != null)
			{
				deletable.Delete();
				await _agreementRepository.UpdateAsync(agreement);
			}
		}

		public async Task<T> GetAgreementAsync<T>(int id)
		{
			var query = _agreementRepository.GetAll(
				i => !i.IsDeleted,
				i => i.Include(a => a.User)
					  .Include(a => a.Product)
					  .Include(a => a.Product.ProductGroup))
				.Where(s => s.Id == id);

			return await Mapper.ProjectTo<T>(query).FirstOrDefaultAsync();
		}

		public async Task<DataTableCriteria<AgreementViewModel>> GetAgreementListAsync(DataTableCriteria<AgreementViewModel> criteria)
		{
			var result = _agreementRepository.GetAll(i => !i.IsDeleted);
			var query = Mapper.ProjectTo<AgreementViewModel>(result);

			//TODO: move pagination and sorting logic in generic repository and get already filtered data from there
			if (!string.IsNullOrEmpty(criteria.SearchingValue))
			{
				query = query.Where(m => m.ProductNumber.Contains(criteria.SearchingValue)
							   || m.ProductGroupCode.Contains(criteria.SearchingValue)
							   || m.Username.Contains(criteria.SearchingValue));
			}

			if (!string.IsNullOrEmpty(criteria.SortingDirection))
			{
				if (criteria.SortingDirection == "desc")
				{
					query = query.OrderByDescending(i => i.Id);
				}
				else
				{
					query = query.OrderBy(i => i.Id);
				}
			}

			criteria.RecordsTotalCount = query.Count();
			criteria.Data = await query.Skip(criteria.Start).Take(criteria.Length).ToListAsync();
			return criteria;
		}

		private void SetCreator(Agreement agreement, Guid userId)
		{
			if (userId == default(Guid))
			{
				throw new InvalidOperationException();
			}

			var creator = agreement as ICreator;
			if (creator == null)
			{
				throw new InvalidCastException();
			}

			creator.SetCreator(userId);
		}
	}
}
