using AutoMapper;
using RESTFulApi.Application.Abstractions.Repositories;
using RESTFulApi.Application.Abstractions.Services;
using RESTFulApi.Application.DTOs.Categories;
using RESTFulApi.Application.DTOs.Products;
using RESTFulApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFulApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositorycs _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepositorycs repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateAsync(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }
         
        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Product not Found");
            await _repository.DeleteAsync(product);
            await _repository.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);  
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Product not found");
            return _mapper.Map<ProductDto?>(product);
        }

        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductRequest request)
        {
            var product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Product not found");
            _mapper.Map(request, product);
            await _repository.UpdateAsync(product);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
