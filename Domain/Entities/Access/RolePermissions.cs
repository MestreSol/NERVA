using Domain.Common;

namespace Domain.Entities.Access
{
    public class RolePermissions : BaseAuditableEntity
    {
        public string RoleId { get; set; } = string.Empty;
        public int PermissionsId { get; set; }
        public Permissions Permissions { get; set; } = new Permissions();
        public bool IsActive { get; set; } = true;
        // Navigation properties
        public AccessRole Role { get; set; } = new AccessRole();

    }
}
