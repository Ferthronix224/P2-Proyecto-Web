using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICaregoriesRepository _caregoriesRepository;

    public CategoriesService(ICaregoriesRepository caregoriesRepository)
    {
        _caregoriesRepository = caregoriesRepository;
    }

    public async Task<CategoriesDto> SaveAsync(CategoriesDto categoriesDto)
    {
        var category = new Categories()
        {
            name = categoriesDto.name,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        category = await _caregoriesRepository.SaveAsync(category);
        category.id = category.id;

        return categoriesDto;
    }

    public async Task<CategoriesDto> UpdateAsync(CategoriesDto categoriesDto)
    {
        var category = await _caregoriesRepository.GetById(categoriesDto.id);

        if (category == null)
            throw new Exception("Product Category Not Found");
        
        category.name = categoriesDto.name;
        category.UpdatedBy = "";
        category.UpdateDate = DateTime.Now;
        
        await _caregoriesRepository.UpdateAsync(category);
        
        return categoriesDto;
    }

    public async Task<List<CategoriesDto>> GetAllAsync()
    {
        var categories = await _caregoriesRepository.GetAllAsync();
        var categoriesDto = categories.Select(c => new CategoriesDto(c)).ToList();
        
        return categoriesDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var category = await _caregoriesRepository.GetById(id);
        return (category != null);
    }

    public async Task<CategoriesDto> GetById(int id)
    {
        var category = await _caregoriesRepository.GetById(id);
        if (category == null)
            throw new Exception("Product Category Not Found");
        var categoryDto = new CategoriesDto(category);
        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _caregoriesRepository.DeleteAsync(id);
    }
}