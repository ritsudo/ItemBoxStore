using ItemBoxStore.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        protected DbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        public Repository(DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            DbSet.Add(entity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            DbSet.Remove(entity);

            return Task.CompletedTask;
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentException(nameof(predicate));
            }

            return DbSet.Where(predicate).AsNoTracking();
        }

        public Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            DbSet.Update(entity);

            return Task.CompletedTask;
        }

        public ValueTask<TEntity> GetByIdAsync(Guid id)
        {
            return DbSet.FindAsync(id);
        }
    }
}
