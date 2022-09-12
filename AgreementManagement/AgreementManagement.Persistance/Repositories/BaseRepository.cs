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

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, CancellationToken cancellationToken = default)
		{
			var query = BuildQuery(include);
			if (predicate != null)
			{
				return await query.AnyAsync(predicate, cancellationToken);
			}

			return await query.AnyAsync(cancellationToken);
		}

		public async Task<TEntity> GetAsync(TKey id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false)
		{
			var query = BuildQuery(include, enableTracking);
			return await query.FirstOrDefaultAsync(r => r.Id.Equals(id));
		}

		public async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false)
		{
			var query = BuildQuery(include, enableTracking);
			if (predicate != null)
			{
				return await query.Where(predicate).FirstOrDefaultAsync();
			}

			return null;
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

		public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = false, CancellationToken cancellationToken = default)
		{
			var query = BuildQuery(include, enableTracking);
			if (predicate != null)
			{
				return await query.SingleOrDefaultAsync(predicate, cancellationToken);
			}

			return null;
		}

		public virtual async Task<int> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().AddRange(entities.ToArray());

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<int> UpdateAsync(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
		{
			var tEntities = entities.ToArray();

			tEntities.ToList().ForEach(e => _context.Entry(e).State = EntityState.Modified);

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<int> RemoveAsync(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
		{
			var tEntities = entities as TEntity[] ?? entities.ToArray();

			_context.Set<TEntity>().RemoveRange(tEntities);

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