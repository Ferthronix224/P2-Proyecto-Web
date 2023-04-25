using Dapper.Contrib.Extensions;
using TecNM.Project.Api.DataAccess;
using TecNM.Project.Api.DataAccess.Interfaces;
using TecNM.Project.Api.Repositories;
using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Api.Services;
using TecNM.Project.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IServiciosRepository, ServiciosRepository>();
builder.Services.AddScoped<IServiciosService, ServiciosService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICiudadesRepository, CiudadesRepository>();
builder.Services.AddScoped<ICiudadesServices, CiudadesService>();
builder.Services.AddScoped<ICaregoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IDbContext, DbContext>();
//builder.Services.AddSingleton<IProductCategoryRepository, ProductCategoryRepository>();

SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("TecNM.Project.Core.Entities."))
        name = name.Replace("TecNM.Project.Core.Entities.", "");

    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();