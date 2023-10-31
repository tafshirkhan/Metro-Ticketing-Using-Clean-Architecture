using System.Linq.Expressions;

namespace Metro.Application.Contracts.Repositories.Command.Base
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Insert data using EF
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);
        /// <summary>
        /// Insert multiple data using EF
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entity);
        /// <summary>
        /// Update data using EF
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);
        /// <summary>
        /// Update Multiple data using EF
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entity);
        /// <summary>
        /// Delete data using EF
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);
        /// <summary>
        /// Delete multiple data using EF
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(IEnumerable<TEntity> entity);

        Task<TEntity> DeleteAsync(object id);
        /// <summary>
        /// Get data using EF
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(object id);
        // <summary>
        /// Get data using EF
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAsync<T>(Expression<Func<TEntity, bool>> predicate) where T : class;
    }
}
