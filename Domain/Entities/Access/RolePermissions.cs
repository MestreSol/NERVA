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
            RoleId = role.Id;
            PermissionsId = permissions.Id;
            Permissions = permissions;
            Role = role;
            IsActive = true;
            Validate();
        }

        public void Validate()
        {
            ValidateGuid(RoleId, nameof(RoleId), "RoleId must be a valid GUID.");
            ValidateGuid(PermissionsId, nameof(PermissionsId), "PermissionsId must be a valid GUID.");

            ValidateObject(Permissions, nameof(Permissions), "Permissions cannot be null.");
            ValidateObject(Role, nameof(Role), "Role cannot be null.");


        }
    }
}
