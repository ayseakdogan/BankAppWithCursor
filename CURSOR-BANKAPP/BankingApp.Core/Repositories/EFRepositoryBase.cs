using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BankingApp.Core.Repositories
{
    public class EFRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public EFRepositoryBase(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (!withDeleted && typeof(TEntity).GetProperty("DeletedDate") != null)
                query = query.Where(e => EF.Property<DateTime?>(e, "DeletedDate") == null);
            return await query.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<Paginate<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (predicate != null) query = query.Where(predicate);
            if (!withDeleted && typeof(TEntity).GetProperty("DeletedDate") != null)
                query = query.Where(e => EF.Property<DateTime?>(e, "DeletedDate") == null);
            if (orderBy != null) query = orderBy(query);
            int totalItems = await query.CountAsync(cancellationToken);
            var items = await query.Skip(index * size).Take(size).ToListAsync(cancellationToken);
            return new Paginate<TEntity>(items, totalItems, new PaginationParams { PageNumber = index + 1, PageSize = size });
        }

        public async Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();
            if (!withDeleted && typeof(TEntity).GetProperty("DeletedDate") != null)
                query = query.Where(e => EF.Property<DateTime?>(e, "DeletedDate") == null);
            if (predicate != null) query = query.Where(predicate);
            return await query.AnyAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, bool permanent = false, CancellationToken cancellationToken = default)
        {
            if (permanent)
            {
                _dbSet.Remove(entity);
            }
            else
            {
                entity.DeletedDate = DateTime.UtcNow;
                _dbSet.Update(entity);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool permanent = false, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                if (permanent)
                {
                    _dbSet.Remove(entity);
                }
                else
                {
                    entity.DeletedDate = DateTime.UtcNow;
                    _dbSet.Update(entity);
                }
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
} 