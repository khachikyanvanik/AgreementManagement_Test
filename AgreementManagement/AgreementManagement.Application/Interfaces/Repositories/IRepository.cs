using AgreementManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AgreementManagement.Application.Interfaces.Repositories
{
	public interface IRepository<TKey, TEntity>
		where TKey : struct
		where TEntity : BaseEntity<TKey>
	{
		Task<TEntity> GetAsync(TKey id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false);
		Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false);
		IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false);
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, CancellationToken cancellationToken = default);
		Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false, CancellationToken cancellationToken = default);

		Task<int> AddAsync(TEntity entity);
		Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
		Task<int> UpdateAsync(TEntity entity);
		Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);
		Task<int> RemoveAsync(TEntity entity);
		Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);
	}
}
