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
		IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false);

		Task<int> AddAsync(TEntity entity);
		Task<int> UpdateAsync(TEntity entity);
	}
}
