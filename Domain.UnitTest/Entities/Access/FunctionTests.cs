using Domain.Entities.Access;
namespace Domain.UnitTest.Entities.Access;


public class FunctionTests
{
    [Fact]
    public void Constructor_ValidParameters_ShouldCreateFunction()
    {
        var name = "Cadastrar Usuario";
        var description = "Permite cadastrar um novo usuário no sistema.";
        var function = new Function(name, description);

        Assert.Equal(name, function.Name);
        Assert.Equal(description, function.Description);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
    {
        var description = "Descrição válida";

        Assert.Throws<ArgumentException>(() => new Function(name, description));
    }

    [Fact]
    public void Constructor_NullName_ShouldThrowArgumentNullException()
    {
        var description = "Descrição válida";

        Assert.Throws<ArgumentNullException>(() => new Function(null, description));
    }
    [Fact]
    public void Constructor_NameTooLong_ShouldThrowArgumentException()
    {
        var name = new string('A', 101);
        var description = "Descrição válida";

        Assert.Throws<ArgumentException>(() => new Function(name, description));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidDescription_ShouldThrowArgumentException(string description)
    {
        var name = "Nome Válido";

        Assert.Throws<ArgumentException>(() => new Function(name, description));
    }

    [Fact]
    public void Constructor_NullDescription_ShouldThrowArgumentNullException()
    {
        var name = "Nome Válido";

        Assert.Throws<ArgumentNullException>(() => new Function(name, null));
    }

    [Fact]
    public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
    {
        var name = "Nome Válido";
        var description = new string('A', 501);

        Assert.Throws<ArgumentException>(() => new Function(name, description));
    }
}