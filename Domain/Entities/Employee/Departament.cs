
using Domain.Common;

namespace Domain.Entities.Employee
{
    public class Departament : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Abreviation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
