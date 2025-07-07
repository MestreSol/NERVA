using Domain.Common;
using Domain.Entities.Access;
namespace Domain.UnitTest.Entities.Access;

public class RolePermissionsTests
{
    public Permissions GetPermissions()
    {
        var description = "Permissões de acesso para o usuário.";
        var localizationsCanAccess = new List<Localization>
        {
            new Localization
            {
                Country = "Brasil",
                City = "São Paulo",
                Address = "Avenida Paulista, 1000",
            }
        };
        var functionsCanAccess = new List<Function>
        {
            new Function("Cadastrar Usuario", "Permite cadastrar um novo usuário no sistema.")
        };

        return new Permissions(description, localizationsCanAccess, functionsCanAccess);
    }
    public AccessRole GetAccessRole()
    {
        return new AccessRole("Administrador", "Acesso total ao sistema.");
    }
    [Fact]
    public void Constructor_ValidParameters_ShouldCreateRolePermissions()
    {
        var permissions = GetPermissions();
        var accessRole = GetAccessRole();

        var rolePermissions = new RolePermissions(permissions, accessRole);
        Assert.Equal(permissions, rolePermissions.Permissions);
        Assert.Equal(accessRole, rolePermissions.Role);
        Assert.True(rolePermissions.IsActive);
    }

    [Fact]
    public void Constructor_NullPermissions_ShouldThrowArgumentNullException()
    {
        var accessRole = GetAccessRole();
        Assert.Throws<ArgumentNullException>(() => new RolePermissions(null, accessRole));
    }
    [Fact]
    public void Constructor_NullRole_ShouldThrowArgumentNullException()
    {
        var permissions = GetPermissions();
        Assert.Throws<ArgumentNullException>(() => new RolePermissions(permissions, null));
    }
}