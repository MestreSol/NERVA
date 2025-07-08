using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Fiscal
{
    public class PurchaseOrder : BaseAuditableEntity
    {
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; } = 0.0m;
        public string SupplierId { get; set; } = string.Empty;
        public UnitOfMeasure UnitOfMeasure { get; set; } = UnitOfMeasure.Kilogram;
        public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
        public Employee.Employee PurchasedBy { get; set; } 
        public Guid PurchasedById { get; set; } = Guid.Empty;
    }
}
