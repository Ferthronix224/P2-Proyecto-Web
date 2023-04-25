using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.Api.DataAccess.Interfaces;
using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories;

public class CiudadesRepository : ICiudadesRepository
{
    private readonly IDbContext _dbContext;

    public CiudadesRepository(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Ciudades> SaveAsync(Ciudades ciudades)
    {
        ciudades.id = await _dbContext.Connection.InsertAsync(ciudades);

        return ciudades;
    }

    public async Task<Ciudades> UpdateAsync(Ciudades ciudades)
    {
        await _dbContext.Connection.UpdateAsync(ciudades);

        return ciudades;
    }

    public async Task<List<Ciudades>> GetAllAsync()
    {
        const string sql = "SELECT * FROM ciudades WHERE IsDeleted = 0";

        var ciudades = await _dbContext.Connection.QueryAsync<Ciudades>(sql);

        return ciudades.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ciudad = await GetById(id);

        if (ciudad == null)
        {
            return false;
        }

        ciudad.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(ciudad);
    }

    public async Task<Ciudades> GetById(int id)
    {
        var ciudad = await _dbContext.Connection.GetAsync<Ciudades>(id);

        if (ciudad == null)
            return null;

        return ciudad.IsDeleted == true ? null : ciudad;
    }
}