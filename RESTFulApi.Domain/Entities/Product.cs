using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFulApi.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;


        // FK
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
