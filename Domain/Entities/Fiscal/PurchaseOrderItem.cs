
using Domain.Common;
using Domain.Entities.Product;
using Domain.Enums;

namespace Domain.Entities.Fiscal
{
    public class PurchaseOrderItem : BaseAuditableEntity
    {
        public Guid PurchaseOrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public Product.Product Product { get; set; }
        public PurchaseOrderItem(PurchaseOrder order, Product.Product product, decimal quality, decimal unitPrice, UnitOfMeasure unitOfMeasure)
        {
            Validate(order, product, quality, unitPrice);
            PurchaseOrder = order;
            Product = product;
            PurchaseOrderId = order.Id;
            ProductId = product.Id;
            Quantity = quality;
            UnitPrice = unitPrice;
            UnitOfMeasure = unitOfMeasure;
        }

        public void Validate(PurchaseOrder order, Product.Product product, decimal quality, decimal unitPrice)
        {
            ValidateObject(order, nameof(PurchaseOrder), "Purchase order cannot be null.");
            ValidateObject(product, nameof(Product), "Product cannot be null.");
            if (quality <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quality));
            }
            if (unitPrice <= 0)
            {
                throw new ArgumentException("Unit price must be greater than zero.", nameof(unitPrice));
            }
        }
    }
 
}
