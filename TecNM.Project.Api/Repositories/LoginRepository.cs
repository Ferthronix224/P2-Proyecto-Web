using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.Api.DataAccess.Interfaces;
using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly IDbContext _dbContext;

    public LoginRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Login> SaveAsync(Login login)
    {
        login.id = await _dbContext.Connection.InsertAsync(login);

        return login;
    }

    public async Task<Login> UpdateAsync(Login login)
    {
        await _dbContext.Connection.UpdateAsync(login);

        return login;
    }

    public async Task<List<Login>> GetAllAsync()
    {
        const string sql = "SELECT * FROM login WHERE IsDeleted = 0";

        var login = await _dbContext.Connection.QueryAsync<Login>(sql);

        return login.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var login = await GetById(id);

        if (login == null)
        {
            return false;
        }

        login.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(login);
    }

    public async Task<Login> GetById(int id)
    {
        var login = await _dbContext.Connection.GetAsync<Login>(id);

        if (login == null)
            return null;

        return login.IsDeleted == true ? null : login;
    }
}