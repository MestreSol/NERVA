using Domain.Common;

namespace Domain.Entities.Access
{
    public class RolePermissions : BaseAuditableEntity
    {
        // Identificador do papel
        public Guid RoleId { get; set; }

        // Identificador das permissões
        public Guid PermissionsId { get; set; }

        // Objeto de permissões associado
        public Permissions Permissions { get; set; }

        // Indica se as permissões estão ativas
        public bool IsActive { get; set; }

        // Objeto de papel associado
        public AccessRole Role { get; set; }

        // Construtor da classe RolePermissions
        public RolePermissions(Guid roleId, Guid permissionsId, Permissions permissions, AccessRole role)
        {
            RoleId = roleId;
            PermissionsId = permissionsId;
            Permissions = permissions ?? throw new ArgumentNullException(nameof(permissions), "Permissions cannot be null.");
            Role = role ?? throw new ArgumentNullException(nameof(role), "Role cannot be null.");
            IsActive = true; // Define como ativo por padrão
            Validate(); // Valida os dados
        }

        // Método para validar os dados do papel e permissões
        public void Validate()
        {
            if (RoleId == Guid.Empty)
                throw new ArgumentException("RoleId must be a valid GUID.", nameof(RoleId));
            if (PermissionsId == Guid.Empty)
                throw new ArgumentException("PermissionsId must be a valid GUID.", nameof(PermissionsId));
            if (Permissions == null)
                throw new ArgumentNullException(nameof(Permissions), "Permissions cannot be null.");
            if (Role == null)
                throw new ArgumentNullException(nameof(Role), "Role cannot be null.");
        }
    }
}
