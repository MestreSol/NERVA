using Domain.Common;

namespace Domain.UnitTest.Entities.Company
{
    public class CompanyTests
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

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateCompany()
        {
            var name = "Empresa Exemplo";
            var description = "Descrição da empresa";
            var identificationNumber = "1234567890";
            var abreviation = "EXEMP";
            var localization = GetValidLocalization();

            // Fix: Fully qualify the Company class to avoid namespace ambiguity
            var company = new Domain.Entities.Company.Company(name, description, identificationNumber, abreviation, localization);

            Assert.Equal(name, company.Name);
            Assert.Equal(description, company.Description);
            Assert.Equal(identificationNumber, company.IdentificationNumber);
            Assert.Equal(abreviation, company.Abreviation);
            Assert.Equal(localization, company.Location);
            Assert.Equal(localization.Id, company.LocalizationId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            var localization = GetValidLocalization();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Domain.Entities.Company.Company(name, "Descrição", "123", "EMP", localization));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longName = new string('a', 201);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Company.Company(longName, "Descrição", "123", "EMP", localization));
        }

        [Fact]
        public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longDescription = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Company.Company("Empresa", longDescription, "123", "EMP", localization));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidIdentificationNumber_ShouldThrowArgumentException(string idNumber)
        {
            var localization = GetValidLocalization();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Domain.Entities.Company.Company("Empresa", "Descrição", idNumber, "EMP", localization));
        }

        [Fact]
        public void Constructor_IdentificationNumberTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longId = new string('1', 51);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Company.Company("Empresa", "Descrição", longId, "EMP", localization));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidAbreviation_ShouldThrowArgumentException(string abrev)
        {
            var localization = GetValidLocalization();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Domain.Entities.Company.Company("Empresa", "Descrição", "123", abrev, localization));
        }

        [Fact]
        public void Constructor_AbreviationTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longAbrev = new string('A', 11);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Company.Company("Empresa", "Descrição", "123", longAbrev, localization));
        }

        [Fact]
        public void Constructor_NullLocalization_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Domain.Entities.Company.Company("Empresa", "Descrição", "123", "EMP", null));
        }
    }
}