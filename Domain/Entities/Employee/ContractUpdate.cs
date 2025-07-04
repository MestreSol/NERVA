using Domain.Common;

namespace Domain.Entities.Employee
{
    public class ContractUpdate : BaseAuditableEntity
    {
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public Employee UpdatedBy { get; set; } = null!;
    }
}
