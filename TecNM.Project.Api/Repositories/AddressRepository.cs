using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.Api.DataAccess.Interfaces;
using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly IDbContext _dbContext;

    public AddressRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Address> SaveAsync(Address address)
    {
        address.id = await _dbContext.Connection.InsertAsync(address);

        return address;
    }

    public async Task<Address> UpdateAsync(Address address)
    {
        await _dbContext.Connection.UpdateAsync(address);

        return address;
    }

    public async Task<List<Address>> GetAllAsync()
    {
        const string sql = "SELECT * FROM address WHERE IsDeleted = 0";

        var address = await _dbContext.Connection.QueryAsync<Address>(sql);

        return address.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var address = await GetById(id);

        if (address == null)
        {
            return false;
        }

        address.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(address);
    }

    public async Task<Address> GetById(int id)
    {
        var login = await _dbContext.Connection.GetAsync<Address>(id);

        if (login == null)
            return null;

        return login.IsDeleted == true ? null : login;
    }
}