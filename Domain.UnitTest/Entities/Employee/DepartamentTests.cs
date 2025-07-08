using Domain.Entities.Employee;

namespace Domain.UnitTest.Entities.Employee
{
    public class DepartamentTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateDepartament()
        {
            var name = "Tecnologia da Informação";
            var abreviation = "TI";
            var description = "Departamento de TI responsável por infraestrutura e sistemas.";

            var departament = new Departament(name, abreviation, description);

            Assert.Equal(name, departament.Name);
            Assert.Equal(abreviation, departament.Abreviation);
            Assert.Equal(description, departament.Description);
            Assert.True(departament.IsActive);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new Departament(name, "TI", "Descrição"));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var longName = new string('a', 201);
            Assert.Throws<ArgumentException>(() =>
                new Departament(longName, "TI", "Descrição"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidAbreviation_ShouldThrowArgumentException(string abrev)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new Departament("TI", abrev, "Descrição"));
        }

        [Fact]
        public void Constructor_AbreviationTooLong_ShouldThrowArgumentException()
        {
            var longAbrev = new string('A', 11);
            Assert.Throws<ArgumentException>(() =>
                new Departament("TI", longAbrev, "Descrição"));
        }

        [Fact]
        public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
        {
            var longDescription = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new Departament("TI", "TI", longDescription));
        }
    }
}