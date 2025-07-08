using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Fiscal
{
    public class PurchaseOrder : BaseAuditableEntity
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string SupplierId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public PurchaseOrderStatus Status { get; set; }
        public Employee.Employee PurchasedBy { get; set; } 
        public Guid PurchasedById { get; set; }

        public PurchaseOrder(string orderNumber, DateTime orderDate, decimal totalAmount, string supplierId, UnitOfMeasure unitOfMeasure, PurchaseOrderStatus status, Employee.Employee purchasedBy)
        {
            Validate(orderNumber, orderDate, totalAmount, supplierId);
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            SupplierId = supplierId;
            UnitOfMeasure = unitOfMeasure;
            Status = status;
            PurchasedBy = purchasedBy;
            PurchasedById = purchasedBy.Id;
        }

        public void Validate(string orderNumber, DateTime orderDate, decimal totalAmount, string supplierId)
        {
            ValidateString(orderNumber, 1, 50, nameof(OrderNumber), "Order number must be between 1 and 50 characters.");
            if (orderDate > DateTime.UtcNow)
            {
                throw new ArgumentException("Order date cannot be in the future.", nameof(orderDate));
            }
            if (totalAmount <= 0)
            {
                throw new ArgumentException("Total amount must be greater than zero.", nameof(totalAmount));
            }
            ValidateString(supplierId, 1, 100, nameof(SupplierId), "Supplier ID must be between 1 and 100 characters.");
        }
    }
}
