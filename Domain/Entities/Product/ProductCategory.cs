using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ProductCategory(string name, string description)
        {
            Validate(name, description);
            Name = name;
            Description = description;
            IsActive = true;
        }

        public void Validate(string name, string description)
        {
            ValidateString(name, 1, 200, nameof(Name), "Name must be between 1 and 200 characters.");
            ValidateString(description, 0, 500, nameof(Description), "Description must be between 0 and 500 characters.");
        }
    }
}
