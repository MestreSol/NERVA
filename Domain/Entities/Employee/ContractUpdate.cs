using Domain.Common;

namespace Domain.Entities.Employee
{
    public class ContractUpdate : BaseAuditableEntity
    {
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdatedById { get; set; }
        public Employee UpdatedBy { get; set; }
        
        public ContractUpdate(Contract contract, Employee updatedBy)
        {
            Validate( contract, updatedBy);
            ContractId = contract.Id;
            Contract = contract;
            UpdatedById = updatedBy.Id;
            UpdatedBy = updatedBy;
            UpdateDate = DateTime.UtcNow;
        }
        private void Validate(Contract contract, Employee updatedBy)
        {
            ValidateObject(contract, nameof(contract), "Contract cannot be null.");
            ValidateObject(updatedBy, nameof(updatedBy), "UpdatedBy cannot be null.");
        }
    }
}
