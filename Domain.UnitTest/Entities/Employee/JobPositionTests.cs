using Domain.Entities.Employee;

namespace Domain.UnitTest.Entities.Employee
{
    public class JobPositionTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateJobPosition()
        {
            var title = "Desenvolvedor";
            var abreviation = "DEV";
            var maxSalary = 15000m;
            var minSalary = 5000m;
            var allocation = 2;

            var position = new JobPosition(title, abreviation, maxSalary, minSalary, allocation);

            Assert.Equal(title, position.Title);
            Assert.Equal(abreviation, position.Abreviation);
            Assert.Equal(maxSalary, position.MaximumSalary);
            Assert.Equal(minSalary, position.MinimumSalary);
            Assert.Equal(allocation, position.AllocationRecomendation);
            Assert.True(position.IsActive);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidTitle_ShouldThrowArgumentException(string title)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new JobPosition(title, "DEV", 10000, 5000, 1));
        }

        [Fact]
        public void Constructor_TitleTooLong_ShouldThrowArgumentException()
        {
            var longTitle = new string('a', 501);
            Assert.Throws<ArgumentException>(() =>
                new JobPosition(longTitle, "DEV", 10000, 5000, 1));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidAbreviation_ShouldThrowArgumentException(string abrev)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new JobPosition("DEV", abrev, 10000, 5000, 1));
        }

        [Fact]
        public void Constructor_AbreviationTooLong_ShouldThrowArgumentException()
        {
            var longAbrev = new string('A', 51);
            Assert.Throws<ArgumentException>(() =>
                new JobPosition("DEV", longAbrev, 10000, 5000, 1));
        }

        [Fact]
        public void Constructor_NegativeMinimumSalary_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new JobPosition("DEV", "DEV", 10000, -1, 1));
        }

        [Fact]
        public void Constructor_NegativeMaximumSalary_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new JobPosition("DEV", "DEV", -1, 0, 1));
        }

        [Fact]
        public void Constructor_MaximumSalaryLessThanMinimumSalary_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new JobPosition("DEV", "DEV", 4000, 5000, 1));
        }

        [Fact]
        public void Constructor_NegativeAllocationRecomendation_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new JobPosition("DEV", "DEV", 10000, 5000, -1));
        }
    }
}