using AgreementManagement.Application.Interfaces.Repositories;
using AgreementManagement.Interfaces.Services;
using AgreementManagement.Persistance;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgreementManagement.Services
{
	public class ProductService : BaseService, IProductService
	{
		private IProductRepository _productRepository;
		private IProductGroupRepository _productGroupRepository;

		public ProductService(
			IProductRepository productRepository,
			IProductGroupRepository productGroupRepository,
			IMapper mapper)
			: base(mapper)
		{
			_productRepository = productRepository;
			_productGroupRepository = productGroupRepository;
		}

		public async Task<List<SelectListItem>> GetProductsAsync()
		{
			var query = _productRepository.GetAll(i => !i.IsDeleted);
			
			return await Mapper.ProjectTo<SelectListItem>(query).ToListAsync();
		}

		public async Task<List<SelectListItem>> GetProductGroupsAsync()
		{
			var query = _productGroupRepository.GetAll(i => !i.IsDeleted);

			return await Mapper.ProjectTo<SelectListItem>(query).ToListAsync();
		}
	}
}
