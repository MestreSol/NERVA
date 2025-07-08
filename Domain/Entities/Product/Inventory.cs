using Domain.Common;
using Domain.Entities.Warehouse;

namespace Domain.Entities.Product
{
    public class Inventory : BaseAuditableEntity
    {
        public Warehouse.Warehouse Warehouse { get; set; }
        public Guid WarehouseId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public Inventory(Warehouse.Warehouse warehouse, Product product, int quantity)
        {
            Validate(warehouse, product, quantity);
            Warehouse = warehouse;
            WarehouseId = warehouse.Id;
            Product = product;
            ProductId = product.Id;
            Quantity = quantity;
        }

        public void Validate(Warehouse.Warehouse warehouse, Product product, int quantity)
        {
            ValidateObject(warehouse, nameof(Warehouse), "Warehouse cannot be null.");
            ValidateObject(product, nameof(Product), "Product cannot be null.");
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            }
        }
    }
}
