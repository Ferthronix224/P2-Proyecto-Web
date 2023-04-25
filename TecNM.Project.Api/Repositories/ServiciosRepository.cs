using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.Api.DataAccess.Interfaces;
using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories;

public class ServiciosRepository : IServiciosRepository
{
    private readonly IDbContext _dbContext;

    public ServiciosRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Servicios> SaveAsync(Servicios servicios)
    {
        servicios.id = await _dbContext.Connection.InsertAsync(servicios);

        return servicios;
    }

    public async Task<Servicios> UpdateAsync(Servicios servicios)
    {
        await _dbContext.Connection.UpdateAsync(servicios);

        return servicios;
    }

    public async Task<List<Servicios>> GetAllAsync()
    {
        const string sql = "SELECT * FROM servicios WHERE IsDeleted = 0";

        var servicios = await _dbContext.Connection.QueryAsync<Servicios>(sql);

        return servicios.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var servicios = await GetById(id);

        if (servicios == null)
        {
            return false;
        }

        servicios.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(servicios);
    }

    public async Task<Servicios> GetById(int id)
    {
        var login = await _dbContext.Connection.GetAsync<Servicios>(id);

        if (login == null)
            return null;

        return login.IsDeleted == true ? null : login;
    }
}