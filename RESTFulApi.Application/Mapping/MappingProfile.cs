namespace RESTFulApi.Application.Mapping;

using AutoMapper;
using RESTFulApi.Application.DTOs.Categories;
using RESTFulApi.Application.DTOs.Products;
using RESTFulApi.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Category Mappings
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();

        // Product Mappings
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
    }
}
