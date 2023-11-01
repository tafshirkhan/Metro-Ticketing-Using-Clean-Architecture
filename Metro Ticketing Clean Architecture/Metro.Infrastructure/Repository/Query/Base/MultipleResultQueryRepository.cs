using Dapper;
using Metro.Application.Contracts.Repositories.Query.Base;
using Metro.Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace Metro.Infrastructure.Repository.Query.Base
{
    public class MultipleResultQueryRepository<TEntity> : QueryRepository<TEntity>, IMultipleResultQueryRepository<TEntity> where TEntity : class
    {
        protected MultipleResultQueryRepository(IConfiguration configuration, IOptions<MetroSettings> settings) : base(configuration, settings)
        {
        }

        //Implementation of IMultipleResultQuery interface
        public async Task<(long, IEnumerable<TEntity>)> GetMultipleResultAsync(string sql, DynamicParameters parameters, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            var grid = await connection.QueryMultipleAsync(sql, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            var result = await grid.ReadAsync<TEntity>();
            var count = (await grid.ReadAsync<long>()).FirstOrDefault();
            return (count, result);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
