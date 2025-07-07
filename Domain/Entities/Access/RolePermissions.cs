using Domain.Common;

namespace Domain.Entities.Access
{
    public class RolePermissions : BaseAuditableEntity
    {
        public Guid RoleId { get; set; }

        public Guid PermissionsId { get; set; }

        public Permissions Permissions { get; set; }

        public bool IsActive { get; set; }

        public AccessRole Role { get; set; }

        public RolePermissions(Permissions permissions, AccessRole role)
        {
            Permissions = permissions;
            Role = role;
            Validate();
            RoleId = role.Id;
            PermissionsId = permissions.Id;
            IsActive = true;
        }

        public void Validate()
        {
            ValidateObject(Permissions, nameof(Permissions), "Permissions cannot be null.");
            ValidateObject(Role, nameof(Role), "Role cannot be null.");
        }
    }
}
