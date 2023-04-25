using System.Data.Common;
using MySqlConnector;
using TecNM.Project.Api.DataAccess.Interfaces;

namespace TecNM.Project.Api.DataAccess;

public class DbContext : IDbContext
{
    private readonly string _connectionString = "server=localhost;user=root;pwd=7724;database=proyecto;port=3306";
    private MySqlConnection _connection;

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            return _connection;
        }
    }
}