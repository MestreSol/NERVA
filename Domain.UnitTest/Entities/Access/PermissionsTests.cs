using Domain.Common;
using Domain.Entities.Access;

namespace Domain.UnitTest.Entities.Access;

public class PermissionsTests
{
    private Localization GetLocalization()
    {
        return new Localization
        {
            Country = "Brasil",
            City = "São Paulo",
            Address = "Avenida Paulista, 1000",
        };
    }

    private Function GetFunction()
    {
        return new Function("Cadastrar Usuario", "Permite cadastrar um novo usuário no sistema.");
    }

    [Fact]
    public void Constructor_ValidParameters_ShouldCreatePermissions()
    {
        var description = "Permissões de acesso para o usuário.";
        var LocalizationsCan = new List<Localization>
        {
            GetLocalization()
        };
        var functionsCan = new List<Function>
        {
            GetFunction()
        };

        var permissions = new Permissions(description, LocalizationsCan, functionsCan);

        Assert.Equal(description, permissions.Description);
        Assert.Equal(LocalizationsCan, permissions.Localizations);
        Assert.Equal(functionsCan, permissions.Functions);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidDescription_ShouldThrowArgumentException(string description)
    {
        var LocalizationsCan = new List<Localization>
        {
            GetLocalization()
        };
        var functionsCan = new List<Function>
        {
            GetFunction()
        };

        Assert.Throws<ArgumentException>(() => new Permissions(description, LocalizationsCan, functionsCan));
    }

    [Fact]
    public void Constructor_NullDescription_ShouldThrowArgumentNullException()
    {
        var LocalizationsCan = new List<Localization>
        {
            GetLocalization()
        };
        var functionsCan = new List<Function>
        {
            GetFunction()
        };

        Assert.Throws<ArgumentNullException>(() => new Permissions(null, LocalizationsCan, functionsCan));
    }

    [Fact]
    public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
    {
        var description = new string('A', 501);
        var LocalizationsCan = new List<Localization>
        {
            GetLocalization()
        };
        var functionsCan = new List<Function>
        {
            GetFunction()
        };

        Assert.Throws<ArgumentException>(() => new Permissions(description, LocalizationsCan, functionsCan));
    }

    [Fact]
    public void Constructor_LocalizationsNull_ShouldThrowArgumentNullException()
    {
        var description = "Permissões de acesso para o usuário.";
        var functionsCan = new List<Function>
        {
            GetFunction()
        };

        Assert.Throws<ArgumentNullException>(() => new Permissions(description, null, functionsCan));
    }
    [Fact]
    public void Constructor_FunctionsNull_ShouldThrowArgumentNullException()
    {
        var description = "Permissões de acesso para o usuário.";
        var LocalizationsCan = new List<Localization>
        {
            GetLocalization()
        };

        Assert.Throws<ArgumentNullException>(() => new Permissions(description, LocalizationsCan, null));
    }
}