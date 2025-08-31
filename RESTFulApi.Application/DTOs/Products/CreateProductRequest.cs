using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFulApi.Application.DTOs.Products
{
    public record CreateProductRequest(string Name, decimal Price, bool IsActive, Guid CategoryId);
}
