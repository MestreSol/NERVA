
using Domain.Common;
using Domain.Entities.Product;

namespace Domain.Entities.Warehouse
{
    public class InOutLog : BaseAuditableEntity
    {
        public Product.Inventory Inventory { get; set; } = null!;
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; } = 0;
        public DateTime LogDate { get; set; } = DateTime.UtcNow;
        public bool IsIn { get; set; } = true; // True for In, False for Out
        public string Description { get; set; } = string.Empty;

    }
}
