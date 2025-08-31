using FluentValidation;
using RESTFulApi.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFulApi.Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x=> x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x=> x.CategoryId).NotEmpty().WithMessage("Category is required");
        RuleFor(x=> x.Price).NotEmpty().WithMessage("Price is required");
    }
}

