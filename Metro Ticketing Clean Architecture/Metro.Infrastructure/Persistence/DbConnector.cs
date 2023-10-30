using Metro.Infrastructure.Configs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace Metro.Infrastructure.Persistence
{
    public class DbConnector
    {
        private readonly IConfiguration _configuration;
        private readonly MetroSettings _settings;
        protected DbConnector(IConfiguration configuration, IOptions<MetroSettings> settings)
        {
            _configuration = configuration;
            _settings = settings.Value;
        }

        public IDbConnection CreateConnection()
        {
            string _connectionString = _settings.ConnectionString.MetroDbConnection;
            return new SqlConnection(_connectionString);
        }
    }
}
