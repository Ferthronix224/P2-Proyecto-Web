using MySql.Data.MySqlClient;
using Proyecto.Api.Repositories.Interfaces;
using Proyecto.Core.Entities;
using Proyecto.Core.MySQL;
using Dapper;
using Proyecto.Core.Http;

namespace Proyecto.Api.Repositories;

public class InMemoryServiceCategoryRepository : IServiceCategoryRepository
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;
    private readonly List<ServiceCategory> _categories;
    private readonly MySQLConfiguration _connectionString;

    public InMemoryServiceCategoryRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    
    public async Task<IEnumerable<ServiceCategory>> GetAllAsync()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM services";

        return await db.QueryAsync<ServiceCategory>(sql, new { });
    }
    
    public async Task<ServiceCategory> GetById(int id)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM services WHERE id = @id";

        return db.QueryFirstOrDefault<ServiceCategory>(sql, new { id = id });
    }
    
    public async Task<bool> SaveAsync(ServiceCategory category)
    {
        var db = dbConnection();

        var sql = @"INSERT INTO services(isDeleted, createdBy, updatedBy, updateDate, name, address, number) VALUES(@isDeleted, @createdBy, @updatedBy, @updateDate, @name, @address, @number)";

        var result = await db.ExecuteAsync(sql, new { category.isDeleted, category.createdBy, category.updatedBy, category.updateDate, category.name, category.address, category.number });
        
        return result > 0;
    }

    public async Task<bool> UpdateAsync(ServiceCategory category)
    {
        var db = dbConnection();

        var sql = @"UPDATE services SET isDeleted = @isDeleted, createdBy = @createdBy, updatedBy = @updatedBy, updateDate = @updateDate, name = @name, address = @address, number = @number WHERE (id = @id)";

        var result = await db.ExecuteAsync(sql, new { category.isDeleted, category.createdBy, category.updatedBy, category.updateDate, category.name, category.address, category.number, category.id });
        
        return result > 0;
    }

    public async Task<bool> DeleteAsync(ServiceCategory category)
    {
        var db = dbConnection();

        var sql = @"DELETE FROM services WHERE id = @id";

        var result = await db.ExecuteAsync(sql, new { id = category.id });

        return result > 0;
    }
}