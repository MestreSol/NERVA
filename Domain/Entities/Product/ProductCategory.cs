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
        public string Name;
        public string Description;
        public bool IsActive = true;
    }
}
