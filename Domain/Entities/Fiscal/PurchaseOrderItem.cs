
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Fiscal
{
    public class PurchaseOrderItem : BaseAuditableEntity
    {
        public string PurchaseOrderId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public decimal Quantity { get; set; } = 0.0m;
        public decimal UnitPrice { get; set; } = 0.0m;
        public decimal TotalPrice => Quantity * UnitPrice;
        public UnitOfMeasure UnitOfMeasure { get; set; } = UnitOfMeasure.Kilogram;
        // Navigation properties
        public PurchaseOrder PurchaseOrder { get; set; } = new();
        public Product.Product Product { get; set; } = new();
    }
 
}
