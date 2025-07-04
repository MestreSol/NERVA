using Domain.Common;

namespace Domain.Entities.Employee
{
    public class JobPosition : BaseAuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Abreviation { get; set; } = string.Empty;
        public decimal MaximumSalary { get; set; }
        public decimal MinimumSalary { get; set; }
        public bool IsActive { get; set; } = true;
        public int AllocationRecomendation { get; set; } = 0;

    }
}
