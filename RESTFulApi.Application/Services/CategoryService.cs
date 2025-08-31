namespace RESTFulApi.Application.Services;

using RESTFulApi.Application.Abstractions.Repositories;
using RESTFulApi.Application.Abstractions.Services;
using RESTFulApi.Application.DTOs.Categories;
using RESTFulApi.Domain.Entities;
using AutoMapper;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto?>(category);
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryRequest request)
    {
        var category = _mapper.Map<Category>(request);
        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryRequest request)
    {
        var category = await _repository.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException("Category not found");

        _mapper.Map(request, category);
        await _repository.UpdateAsync(category);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException("Category not found");

        await _repository.DeleteAsync(category);
        await _repository.SaveChangesAsync();
        return true;
    }
}
