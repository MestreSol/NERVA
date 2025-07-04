using Domain.Common;
using Domain.Entities.Warehouse;

namespace Domain.Entities.Product
{
    public class Inventory : BaseAuditableEntity
    {
        public Warehouse.Warehouse Warehouse { get; set; } = null!;
        public Guid WarehouseId { get; set; }
        public Product Product { get; set; } = null!;
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } = 0; 
    }
}
