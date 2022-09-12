using AgreementManagement.Application.Interfaces.Repositories;
using AgreementManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AgreementManagement.Persistance.Repositories
{
	public class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity>
			where TKey : struct
			where TEntity : BaseEntity<TKey>
	{
		protected readonly AgreementManagementDbContext _context;

		public BaseRepository(AgreementManagementDbContext context)
		{
			_context = context;
		}

		public async Task<TEntity> GetAsync(TKey id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false)
		{
			var query = BuildQuery(include, enableTracking);
			return await query.FirstOrDefaultAsync(r => r.Id.Equals(id));
		}

		public virtual IQueryable<TEntity> GetAll(
			Expression<Func<TEntity, bool>> predicate = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
			bool enableTracking = false)
		{
			var query = BuildQuery(include, enableTracking);
			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			return query;
		}

		public virtual async Task<int> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<int> UpdateAsync(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;

			return await _context.SaveChangesAsync();
		}

		#region Private Methods
		private IQueryable<TEntity> BuildQuery(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false)
		{
			var query = _context.Set<TEntity>().AsQueryable();
			if (include != null)
			{
				query = include(query);
			}

			if (!enableTracking)
			{
				query = query.AsNoTracking();
			}

			return query;
		}
		#endregion
	}
}