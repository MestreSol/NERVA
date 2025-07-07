using Domain.Entities.Access;

namespace Domain.UnitTest.Entities.Access
{
    public class AccessRoleTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateAccessRole()
        {
            var name = "Administrador";
            var description = "Permite acesso total ao sistema.";

            var role = new AccessRole(name, description);

            Assert.Equal(name, role.Name);
            Assert.Equal(description, role.Description);
            Assert.True(role.IsActive);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            var description = "Descrição válida para o papel.";
            Assert.Throws<ArgumentException>(() => new AccessRole(name, description));
        }

        [Fact]
        public void Constructor_NullName_ShouldThrowArgumentNullException()
        {
            var description = "Descrição válida para o papel.";
            Assert.Throws<ArgumentNullException>(() => new AccessRole(null, description));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var name = new string('a', 101);
            var description = "Descrição válida para o papel.";
            Assert.Throws<ArgumentException>(() => new AccessRole(name, description));
        }

        [Fact]
        public void Constructor_NullDescription_ShouldThrowArgumentNullException()
        {
            var name = "Administrador";
            Assert.Throws<ArgumentNullException>(() => new AccessRole(name, null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("curta")]
        [InlineData("123456789")] // 9 caracteres
        public void Constructor_DescriptionTooShort_ShouldThrowArgumentException(string description)
        {
            var name = "Administrador";
            Assert.Throws<ArgumentException>(() => new AccessRole(name, description));
        }

        [Fact]
        public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
        {
            var name = "Administrador";
            var description = new string('d', 501);
            Assert.Throws<ArgumentException>(() => new AccessRole(name, description));
        }
    }
}
