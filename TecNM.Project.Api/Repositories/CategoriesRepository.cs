using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.Api.DataAccess.Interfaces;
using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories;

public class CategoriesRepository : ICaregoriesRepository
{
    private readonly IDbContext _dbContext;

    public CategoriesRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Categories> SaveAsync(Categories categories)
    {
        categories.id = await _dbContext.Connection.InsertAsync(categories);

        return categories;
    }

    public async Task<Categories> UpdateAsync(Categories categories)
    {
        await _dbContext.Connection.UpdateAsync(categories);

        return categories;
    }

    public async Task<List<Categories>> GetAllAsync()
    {
        const string sql = "SELECT * FROM categories WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<Categories>(sql);

        return categories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await GetById(id);

        if (category == null)
        {
            return false;
        }

        category.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(category);
    }

    public async Task<Categories> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<Categories>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }
}