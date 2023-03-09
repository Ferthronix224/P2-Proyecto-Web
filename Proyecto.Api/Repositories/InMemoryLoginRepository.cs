using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Api.Repositories.Interfaces;
using Proyecto.Core.Entities;
using Proyecto.Core.MySQL;

namespace Proyecto.Api.Repositories;

public class InMemoryLoginRepository : ILoginRepository
{
    private readonly ILoginRepository _loginRepository;
    private readonly List<Login> _login;
    private readonly MySQLConfiguration _connectionString;

    public InMemoryLoginRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }

    public async Task<bool> SaveAsync(Login login)
    {
        var db = dbConnection();

        var sql = @"INSERT INTO login(user, password) VALUES(@user, @password)";

        var result = await db.ExecuteAsync(sql, new { login.user, login.password });
        
        return result > 0;
    }

    public async Task<bool> UpdateAsync(Login login)
    {
        var db = dbConnection();

        var sql = @"UPDATE login SET user = @user, password = @password WHERE (id = @id)";

        var result = await db.ExecuteAsync(sql, new { login.user, login.password, login.id });
        
        return result > 0;
    }

    public async Task<IEnumerable<Login>> GetAllAsync()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM login";

        return await db.QueryAsync<Login>(sql, new { });
    }

    public async Task<bool> DeleteAsync(Login login)
    {
        var db = dbConnection();

        var sql = @"DELETE FROM login WHERE id = @id";

        var result = await db.ExecuteAsync(sql, new { id = login.id });

        return result > 0;
    }

    public async Task<Login> GetById(int id)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM login WHERE id = @id";

        return db.QueryFirstOrDefault<Login>(sql, new { id = id });
    }
}