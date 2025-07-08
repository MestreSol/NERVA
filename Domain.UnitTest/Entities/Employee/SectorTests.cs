using Domain.Entities.Employee;

namespace Domain.UnitTest.Entities.Employee
{
    public class SectorTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateSector()
        {
            var name = "Financeiro";
            var description = "Setor responsável pelas finanças da empresa.";

            var sector = new Sector(name, description);

            Assert.Equal(name, sector.Name);
            Assert.Equal(description, sector.Description);
            Assert.True(sector.IsActive);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new Sector(name, "Descrição"));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var longName = new string('a', 201);
            Assert.Throws<ArgumentException>(() =>
                new Sector(longName, "Descrição"));
        }

        [Fact]
        public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
        {
            var longDescription = new string('a', 501);
            Assert.Throws<ArgumentException>(() =>
                new Sector("Financeiro", longDescription));
        }
    }
}