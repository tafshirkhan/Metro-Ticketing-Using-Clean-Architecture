﻿using Dapper;
using Metro.Application.Contracts.Repositories.Query.Base;
using Metro.Infrastructure.Configs;
using Metro.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace Metro.Infrastructure.Repository.Query.Base
{
    public class QueryRepository<TEntity> : DbConnector, IDisposable, IQueryRepository<TEntity> where TEntity : class
    {
        protected QueryRepository(IConfiguration configuration, IOptions<MetroSettings> settings) : base(configuration, settings)
        {

        }

        public async Task<IEnumerable<TEntity>> GetAsync(string sql, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TEntity>(sql, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(string sql, DynamicParameters parameters, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TEntity>(sql, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TEntity>(string sql, Func<TFirst, TSecond, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure: CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TEntity>(string sql, Func<TFirst, TSecond, TEntity> map, DynamicParameters parameters, string splitters = "Id", bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TEntity>(string sql, Func<TFirst, TSecond, TThird, TEntity> map, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text, splitOn: splitters);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TEntity>(string sql, Func<TFirst, TSecond, TThird, TEntity> map, DynamicParameters parameters, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text, splitOn: splitters);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TEntity> map, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text, splitOn: splitters);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TEntity> map, DynamicParameters parameters, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text, splitOn: splitters);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> map, DynamicParameters parameters, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text, splitOn: splitters);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, DynamicParameters parameters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TSeventh : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, DynamicParameters parameters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TSeventh : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

       

        public async Task<TEntity> SingleAsync(string sql, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<TEntity> SingleAsync(string sql, DynamicParameters parameters, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<long> SingleCountAsync(string sql, DynamicParameters parameters, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<long>(sql, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }
        public async Task<TEntity> SingleAsync<TFirst, TSecond, TEntity>(string sql, Func<TFirst, TSecond, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
        {
            using var connection = CreateConnection();
            return (TEntity)await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TEntity>(string sql, Func<TFirst, TSecond, TEntity> map, DynamicParameters parameters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TEntity>(string sql, Func<TFirst, TSecond, TThird, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TEntity>(string sql, Func<TFirst, TSecond, TThird, TEntity> map, DynamicParameters parameters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TEntity> map, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            return (TEntity)await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text, splitOn: splitters);
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TEntity> map, DynamicParameters parameters, string splitters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text, splitOn: splitters);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> map, DynamicParameters parameters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, DynamicParameters parameters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TSeventh : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }

        public async Task<TEntity> SingleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, DynamicParameters parameters, bool isProcedure = false)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TSixth : class
            where TSeventh : class
            where TEntity : class
        {
            using var connection = CreateConnection();
            var returnedData = await connection.QueryAsync(sql, map, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            return returnedData == null ? default : returnedData.FirstOrDefault();
        }


        public async Task<DataTable> GetDataTableAsync(string sql, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            var reader = await connection.ExecuteReaderAsync(sql, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);

            DataTable table = new();
            table.Load(reader);
            return table;
        }

        public async Task<DataTable> GetDataTableAsync(string sql, DynamicParameters parameters, bool isProcedure = false)
        {
            using var connection = CreateConnection();
            var reader = await connection.ExecuteReaderAsync(sql, parameters, commandType: isProcedure ? CommandType.StoredProcedure : CommandType.Text);
            var table = new DataTable();
            table.Load(reader);

            return table;
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
