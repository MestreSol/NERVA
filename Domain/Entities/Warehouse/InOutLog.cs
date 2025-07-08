
using Domain.Common;
using Domain.Entities.Product;

namespace Domain.Entities.Warehouse
{
    public class InOutLog : BaseAuditableEntity
    {
        public Product.Inventory Inventory { get; set; }
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public DateTime LogDate { get; set; }
        public bool IsIn { get; set; }
        public string Description { get; set; }

        public InOutLog(Product.Inventory inventory, int quantity, bool isIn, string description)
        {
            Validate(inventory, quantity, description);
            Inventory = inventory;
            InventoryId = inventory.Id;
            Quantity = quantity;
            LogDate = DateTime.UtcNow;
            IsIn = isIn;
            Description = description;
        }

        public void Validate(Product.Inventory inventory, int quantity, string description)
        {
            ValidateObject(inventory, nameof(Inventory), "Inventory cannot be null.");
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }
            ValidateString(description, 0, 500, nameof(Description), "Description must be between 0 and 500 characters.");
        }
    }
}
