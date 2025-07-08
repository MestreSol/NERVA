using Domain.Common;
using Domain.Entities.Company;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Company
{
    public class OperationTests
    {
        private Localization GetValidLocalization()
        {
            return new Localization
            {
                Id = Guid.NewGuid(),
                Country = "Brasil",
                City = "São Paulo",
                Address = "Av. Paulista, 1000"
            };
        }

        private Domain.Entities.Company.Company GetValidCompany()
        {
            var localization = GetValidLocalization();
            return new Domain.Entities.Company.Company(
                "Empresa Exemplo",
                "Descrição da empresa",
                "1234567890",
                "EXEMP",
                localization
            );
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateOperation()
        {
            var name = "Operação 1";
            var description = "Descrição da operação";
            var iconUrl = "https://site.com/icon.png";
            var type = OperationType.Sale;
            var company = GetValidCompany();
            var localization = GetValidLocalization();

            var operation = new Operation(name, description, iconUrl, type, company, localization);

            Assert.Equal(name, operation.Name);
            Assert.Equal(description, operation.Description);
            Assert.Equal(iconUrl, operation.IconUrl);
            Assert.Equal(type, operation.Type);
            Assert.Equal(company, operation.Company);
            Assert.Equal(company.Id, operation.CompanyId);
            Assert.Equal(localization, operation.Localization);
            Assert.Equal(localization.Id, operation.LocalizationId);
            Assert.True(operation.IsActive);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            var company = GetValidCompany();
            var localization = GetValidLocalization();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Operation(name, "Descrição", null, OperationType.Sale, company, localization));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var company = GetValidCompany();
            var localization = GetValidLocalization();
            var longName = new string('a', 201);
            Assert.Throws<ArgumentException>(() =>
                new Operation(longName, "Descrição", null, OperationType.Sale, company, localization));
        }

        [Fact]
        public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
        {
            var company = GetValidCompany();
            var localization = GetValidLocalization();
            var longDescription = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new Operation("Operação", longDescription, null, OperationType.Sale, company, localization));
        }

        [Fact]
        public void Constructor_NullCompany_ShouldThrowArgumentNullException()
        {
            var localization = GetValidLocalization();
            Assert.Throws<ArgumentNullException>(() =>
                new Operation("Operação", "Descrição", null, OperationType.Sale, null, localization));
        }

        [Fact]
        public void Constructor_NullLocalization_ShouldThrowArgumentNullException()
        {
            var company = GetValidCompany();
            Assert.Throws<ArgumentNullException>(() =>
                new Operation("Operação", "Descrição", null, OperationType.Sale, company, null));
        }

        [Fact]
        public void Constructor_IconUrlTooLong_ShouldThrowArgumentOutOfRangeException()
        {
            var company = GetValidCompany();
            var localization = GetValidLocalization();
            var longIconUrl = new string('a', 501);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Operation("Operação", "Descrição", longIconUrl, OperationType.Sale, company, localization));
        }
    }
}