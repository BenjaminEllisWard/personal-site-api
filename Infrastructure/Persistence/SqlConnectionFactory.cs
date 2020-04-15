using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using Infrastructure.Models;

namespace Infrastructure.Persistence
{
    public interface ISqlConnectionFactory
    {
        SqlConnection Open();
    }

    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IOptions<ConnectionStrings> _connectionStrings;

        public SqlConnectionFactory(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public SqlConnection Open()
        {
            return new SqlConnection(_connectionStrings.Value.SqlServer);
        }
    }
}
