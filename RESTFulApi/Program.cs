

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RESTFulApi.Application.Abstractions.Repositories;
using RESTFulApi.Application.Abstractions.Services;
using RESTFulApi.Application.Mapping;
using RESTFulApi.Application.Services;
using RESTFulApi.Application.Validators;
using RESTFulApi.Infrastructure.Context;
using RESTFulApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------
// 1. Add DbContext (EF Core)
// ------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));

// ------------------------------------------------
// 2. Add Repositories (Infra Layer)
// ------------------------------------------------

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepositorycs, ProductRepository>();

// ------------------------------------------------
// 3. Add Services (Application Layer)
// ------------------------------------------------

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService,  ProductService>();

// ------------------------------------------------
// 4. Add AutoMapper (Mapping Profile)
// ------------------------------------------------
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ------------------------------------------------
// 5. Add FluentValidation
// ------------------------------------------------
// Add controllers
builder.Services.AddControllers();

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

// Register all validators automatically from the assembly
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
// ------------------------------------------------
// 6. Add Swagger
// ------------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ------------------------------------------------
// Configure HTTP Request Pipeline
// ------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
