using Domain.Entities.Fiscal;
using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Fiscal
{
    public class PurchaseOrderTests
    {
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

        [Fact]
        public void Constructor_ValidParameters_ShouldCreatePurchaseOrder()
        {
            var orderNumber = "PO-12345";
            var orderDate = DateTime.UtcNow.AddDays(-1);
            var totalAmount = 1000m;
            var supplierId = "SUP-001";
            var unit = UnitOfMeasure.Piece;
            var status = PurchaseOrderStatus.Approved;
            var employee = GetValidEmployee();

            var order = new PurchaseOrder(orderNumber, orderDate, totalAmount, supplierId, unit, status, employee);

            Assert.Equal(orderNumber, order.OrderNumber);
            Assert.Equal(orderDate, order.OrderDate);
            Assert.Equal(totalAmount, order.TotalAmount);
            Assert.Equal(supplierId, order.SupplierId);
            Assert.Equal(unit, order.UnitOfMeasure);
            Assert.Equal(status, order.Status);
            Assert.Equal(employee, order.PurchasedBy);
            Assert.Equal(employee.Id, order.PurchasedById);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidOrderNumber_ShouldThrowArgumentException(string orderNumber)
        {
            var employee = GetValidEmployee();
            Assert.ThrowsAny<ArgumentException>(() =>
                new PurchaseOrder(orderNumber, DateTime.UtcNow.AddDays(-1), 1000, "SUP-001", UnitOfMeasure.Piece, PurchaseOrderStatus.Approved, employee));
        }

        [Fact]
        public void Constructor_OrderNumberTooLong_ShouldThrowArgumentException()
        {
            var employee = GetValidEmployee();
            var longOrderNumber = new string('A', 51);
            Assert.Throws<ArgumentException>(() =>
                new PurchaseOrder(longOrderNumber, DateTime.UtcNow.AddDays(-1), 1000, "SUP-001", UnitOfMeasure.Piece, PurchaseOrderStatus.Approved, employee));
        }

        [Fact]
        public void Constructor_OrderDateInFuture_ShouldThrowArgumentException()
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new PurchaseOrder("PO-12345", DateTime.UtcNow.AddDays(1), 1000, "SUP-001", UnitOfMeasure.Piece, PurchaseOrderStatus.Approved, employee));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidTotalAmount_ShouldThrowArgumentException(decimal totalAmount)
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new PurchaseOrder("PO-12345", DateTime.UtcNow.AddDays(-1), totalAmount, "SUP-001", UnitOfMeasure.Piece, PurchaseOrderStatus.Approved, employee));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidSupplierId_ShouldThrowArgumentException(string supplierId)
        {
            var employee = GetValidEmployee();
            Assert.ThrowsAny<ArgumentException>(() =>
                new PurchaseOrder("PO-12345", DateTime.UtcNow.AddDays(-1), 1000, supplierId, UnitOfMeasure.Piece, PurchaseOrderStatus.Approved, employee));
        }

        [Fact]
        public void Constructor_SupplierIdTooLong_ShouldThrowArgumentException()
        {
            var employee = GetValidEmployee();
            var longSupplierId = new string('S', 101);
            Assert.Throws<ArgumentException>(() =>
                new PurchaseOrder("PO-12345", DateTime.UtcNow.AddDays(-1), 1000, longSupplierId, UnitOfMeasure.Piece, PurchaseOrderStatus.Approved, employee));
        }
    }
}