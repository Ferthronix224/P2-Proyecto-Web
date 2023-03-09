using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Api.Repositories.Interfaces;
using Proyecto.Core.Entities;
using Proyecto.Core.MySQL;

namespace Proyecto.Api.Repositories;

public class InMemoryCategoriasRepository : ICategoriasRepository
{
    private readonly ICategoriasRepository _categoriasRepository;
    private readonly List<Categorias> _categories;
    private readonly MySQLConfiguration _connectionString;

    public InMemoryCategoriasRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    
    public async Task<bool> SaveAsync(Categorias category)
    {
        var db = dbConnection();

        var sql = @"INSERT INTO categorias(name) VALUES(@name)";

        var result = await db.ExecuteAsync(sql, new { category.name });
        
        return result > 0;
    }

    public async Task<bool> UpdateAsync(Categorias category)
    {
        var db = dbConnection();

        var sql = @"UPDATE categorias SET name = @name WHERE (id = @id)";

        var result = await db.ExecuteAsync(sql, new { category.name, category.id });
        
        return result > 0;
    }

    public async Task<IEnumerable<Categorias>> GetAllAsync()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM categorias";

        return await db.QueryAsync<Categorias>(sql, new { });
    }

    public async Task<bool> DeleteAsync(Categorias category)
    {
        var db = dbConnection();

        var sql = @"DELETE FROM categorias WHERE id = @id";

        var result = await db.ExecuteAsync(sql, new { id = category.id });

        return result > 0;
    }

    public async Task<Categorias> GetById(int id)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM categorias WHERE id = @id";

        return db.QueryFirstOrDefault<Categorias>(sql, new { id = id });
    }
}