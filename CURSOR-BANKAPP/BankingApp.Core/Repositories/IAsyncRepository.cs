using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace BankingApp.Core.Repositories
{
    public interface IAsyncRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        // Get
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        // Get List
        Task<Paginate<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        // Any
        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        // Add
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        // Update
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        // Delete
        Task DeleteAsync(TEntity entity, bool permanent = false, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool permanent = false, CancellationToken cancellationToken = default);
    }
} 