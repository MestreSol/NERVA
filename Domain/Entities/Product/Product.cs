using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Product : BaseAuditableEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0m;
        public ProductCategory ProductCategory { get; set; }
        public bool IsActive { get; set; } = true;

        public Product(string code, string name, string description, decimal price, ProductCategory productCategory)
        {
            Validate(code, name, description, price, productCategory);
            Code = code;
            Name = name;
            Description = description;
            Price = price;
            ProductCategory = productCategory;
        }

        public void Validate(string code, string name, string description, decimal price, ProductCategory productCategory)
        {
            ValidateString(code, 1, 50, nameof(Code), "Code must be between 1 and 50 characters.");
            ValidateString(name, 1, 100, nameof(Name), "Name must be between 1 and 100 characters.");
            ValidateString(description, 0, 500, nameof(Description), "Description must be between 0 and 500 characters.");
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }
            if (productCategory == null)
            {
                throw new ArgumentNullException(nameof(productCategory), "Product category cannot be null.");
            }
        }
    }
}
