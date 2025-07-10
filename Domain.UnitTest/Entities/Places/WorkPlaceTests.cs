using Domain.Common;
using Domain.Entities.Places;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Places
{
    public class WorkPlaceTests
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
        public void Constructor_ValidParameters_ShouldCreateWorkPlace()
        {
            var code = "WP-001";
            var name = "Sala de Reunião";
            var abreviation = "SR";
            var description = "Sala para reuniões de equipe";
            var localization = GetValidLocalization();
            var floor = "3";
            var building = "Edifício Central";
            var maxCampacity = 10;
            var type = WorkPlaceType.MeetingRoom;

            var workPlace = new WorkPlace(code, name, abreviation, description, localization, floor, building, maxCampacity, type);

            Assert.Equal(code, workPlace.Code);
            Assert.Equal(name, workPlace.Name);
            Assert.Equal(abreviation, workPlace.Abreviation);
            Assert.Equal(description, workPlace.Description);
            Assert.Equal(localization, workPlace.Localization);
            Assert.Equal(floor, workPlace.Floor);
            Assert.Equal(building, workPlace.Building);
            Assert.Equal(maxCampacity, workPlace.MaxCampacity);
            Assert.True(workPlace.IsActive);
            Assert.Equal(type, workPlace.WorkPlaceType);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidCode_ShouldThrowArgumentException(string code)
        {
            var localization = GetValidLocalization();
            Assert.ThrowsAny<ArgumentException>(() =>
                new WorkPlace(code, "Nome", "ABR", "Descrição", localization, "1", "Prédio", 5, WorkPlaceType.Office));
        }

        [Fact]
        public void Constructor_CodeTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longCode = new string('C', 51);
            Assert.Throws<ArgumentException>(() =>
                new WorkPlace(longCode, "Nome", "ABR", "Descrição", localization, "1", "Prédio", 5, WorkPlaceType.Office));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            var localization = GetValidLocalization();
            Assert.ThrowsAny<ArgumentException>(() =>
                new WorkPlace("CODE", name, "ABR", "Descrição", localization, "1", "Prédio", 5, WorkPlaceType.Office));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longName = new string('N', 101);
            Assert.Throws<ArgumentException>(() =>
                new WorkPlace("CODE", longName, "ABR", "Descrição", localization, "1", "Prédio", 5, WorkPlaceType.Office));
        }

        [Fact]
        public void Constructor_AbreviationTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longAbrev = new string('A', 21);
            Assert.Throws<ArgumentException>(() =>
                new WorkPlace("CODE", "Nome", longAbrev, "Descrição", localization, "1", "Prédio", 5, WorkPlaceType.Office));
        }

        [Fact]
        public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longDesc = new string('D', 501);
            Assert.Throws<ArgumentException>(() =>
                new WorkPlace("CODE", "Nome", "ABR", longDesc, localization, "1", "Prédio", 5, WorkPlaceType.Office));
        }

        [Fact]
        public void Constructor_NullLocalization_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WorkPlace("CODE", "Nome", "ABR", "Descrição", null, "1", "Prédio", 5, WorkPlaceType.Office));
        }

        [Fact]
        public void Constructor_FloorTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longFloor = new string('F', 51);
            Assert.Throws<ArgumentException>(() =>
                new WorkPlace("CODE", "Nome", "ABR", "Descrição", localization, longFloor, "Prédio", 5, WorkPlaceType.Office));
        }

        [Fact]
        public void Constructor_BuildingTooLong_ShouldThrowArgumentException()
        {
            var localization = GetValidLocalization();
            var longBuilding = new string('B', 101);
            Assert.Throws<ArgumentException>(() =>
                new WorkPlace("CODE", "Nome", "ABR", "Descrição", localization, "1", longBuilding, 5, WorkPlaceType.Office));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidMaxCampacity_ShouldThrowArgumentException(int maxCampacity)
        {
            var localization = GetValidLocalization();
            Assert.Throws<ArgumentException>(() =>
                new WorkPlace("CODE", "Nome", "ABR", "Descrição", localization, "1", "Prédio", maxCampacity, WorkPlaceType.Office));
        }
    }
}