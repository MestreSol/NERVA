using Domain.Entities.Fiscal;
using Domain.Entities.Product;
using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Fiscal
{
    public class PurchaseOrderItemTests
    {
        private Product GetValidProduct()
        {
            return new Product(
                code: "P001",
                name: "Produto Teste",
                description: "Descrição do produto",
                price: 10.5m,
                productCategory: new ProductCategory("Categoria", "Descrição da categoria")
            );
        }

        private Domain.Entities.Employee.Employee GetValidEmployee()
        {
            return new Domain.Entities.Employee.Employee(
                firstName: "João",
                lastName: "Silva",
                email: "joao@empresa.com",
                phoneNumber: "11999999999",
                dateOfBirth: new DateTime(1990, 1, 1),
                position: new JobPosition(
                    title: "Analista",
                    abreviation: "ANL",
                    maximumSalary: 10000,
                    minimumSalary: 5000,
                    allocationRecomendation: 1
                ),
                type: EmployeeType.FullTime,
                salary: 7000,
                status: EmployeeStatus.Active,
                departament: new Departament(
                    name: "TI",
                    abreviation: "TI",
                    description: "Tecnologia da Informação"
                )
            );
        }

        private PurchaseOrder GetValidPurchaseOrder()
        {
            var employee = GetValidEmployee();
            return new PurchaseOrder(
                orderNumber: "PO-12345",
                orderDate: DateTime.UtcNow.AddDays(-1),
                totalAmount: 1000m,
                supplierId: "SUP-001",
                unitOfMeasure: UnitOfMeasure.Piece,
                status: PurchaseOrderStatus.Approved,
                purchasedBy: employee
            );
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreatePurchaseOrderItem()
        {
            var order = GetValidPurchaseOrder();
            var product = GetValidProduct();
            var quantity = 5m;
            var unitPrice = 20m;
            var unitOfMeasure = UnitOfMeasure.Piece;

            var item = new PurchaseOrderItem(order, product, quantity, unitPrice, unitOfMeasure);

            Assert.Equal(order, item.PurchaseOrder);
            Assert.Equal(order.Id, item.PurchaseOrderId);
            Assert.Equal(product, item.Product);
            Assert.Equal(product.Id, item.ProductId);
            Assert.Equal(quantity, item.Quantity);
            Assert.Equal(unitPrice, item.UnitPrice);
            Assert.Equal(quantity * unitPrice, item.TotalPrice);
            Assert.Equal(unitOfMeasure, item.UnitOfMeasure);
        }

        [Fact]
        public void Constructor_NullOrder_ShouldThrowArgumentNullException()
        {
            var product = GetValidProduct();
            Assert.Throws<ArgumentNullException>(() =>
                new PurchaseOrderItem(null, product, 1, 10, UnitOfMeasure.Piece));
        }

        [Fact]
        public void Constructor_NullProduct_ShouldThrowArgumentNullException()
        {
            var order = GetValidPurchaseOrder();
            Assert.Throws<ArgumentNullException>(() =>
                new PurchaseOrderItem(order, null, 1, 10, UnitOfMeasure.Piece));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidQuantity_ShouldThrowArgumentException(decimal quantity)
        {
            var order = GetValidPurchaseOrder();
            var product = GetValidProduct();
            Assert.Throws<ArgumentException>(() =>
                new PurchaseOrderItem(order, product, quantity, 10, UnitOfMeasure.Piece));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void Constructor_InvalidUnitPrice_ShouldThrowArgumentException(decimal unitPrice)
        {
            var order = GetValidPurchaseOrder();
            var product = GetValidProduct();
            Assert.Throws<ArgumentException>(() =>
                new PurchaseOrderItem(order, product, 1, unitPrice, UnitOfMeasure.Piece));
        }
    }
}