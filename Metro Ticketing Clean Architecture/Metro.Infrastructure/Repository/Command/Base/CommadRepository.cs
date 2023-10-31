using Metro.Application.Contracts.Repositories.Command.Base;
using Metro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Metro.Infrastructure.Repository.Command.Base
{
    public class CommadRepository<TEntity> : IDisposable, ICommandRepository<TEntity> where TEntity : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<TEntity> _dbSet;

        public CommadRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;           
        }

        protected DbSet<TEntity> DbSet
        {
            get => _dbSet ??= _dbFactory.DbContext.Set<TEntity>();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            DbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entity)
        {
           if(entity==null)
                throw new ArgumentNullException(nameof(entity));
           DbSet.RemoveRange(entity);
           await Task.CompletedTask;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            await DbSet.AddAsync(entity);
            return entity;

        }

        public async Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            await DbSet.AddRangeAsync(entity);
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            DbSet.Update(entity);
            await Task.CompletedTask;
            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            DbSet.UpdateRange(entity);
            await Task.CompletedTask;
            return entity;
        }

        public async Task<TEntity> DeleteAsync(object id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var data = await DbSet.FindAsync(id);
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            DbSet.Remove(data);
            await Task.CompletedTask;
            return data;
        }

        public void Dispose()
        {
            _dbFactory.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> FindAsync<T>(Expression<Func<TEntity, bool>> predicate) where T : class
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

    }
}
