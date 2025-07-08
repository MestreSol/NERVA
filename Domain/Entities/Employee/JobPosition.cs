using Domain.Common;

namespace Domain.Entities.Employee
{
    public class JobPosition : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Abreviation { get; set; }
        public decimal MaximumSalary { get; set; }
        public decimal MinimumSalary { get; set; }
        public bool IsActive { get; set; } = true;
        public int AllocationRecomendation { get; set; }

        public JobPosition(string title, string abreviation, decimal maximumSalary, decimal minimumSalary, int allocationRecomendation)
        {
            Validate(title, abreviation, maximumSalary, minimumSalary, allocationRecomendation);
            Title = title;
            Abreviation = abreviation;
            MaximumSalary = maximumSalary;
            MinimumSalary = minimumSalary;
            AllocationRecomendation = allocationRecomendation;
        }

        public void Validate(string title, string abreviation, decimal maximumSalary, decimal minimumSalary, int allocationRecomendation)
        {
            ValidateString(title, 1, 500, nameof(title), "Title cannot be empty or exceed 500 characters.");
            ValidateString(abreviation, 1, 50, nameof(abreviation), "Abreviation cannot be empty or exceed 50 characters.");
            if(minimumSalary < 0)
            {
                throw new ArgumentException("Minimum salary cannot be negative.", nameof(minimumSalary));
            }
            if(maximumSalary < 0)
            {
                throw new ArgumentException("Maximum salary cannot be negative.", nameof(maximumSalary));
            }
            if(maximumSalary < minimumSalary)
            {
                throw new ArgumentException("Maximum salary cannot be less than minimum salary.", nameof(maximumSalary));
            }
            if (allocationRecomendation < 0)
            {
                throw new ArgumentException("Allocation recommendation cannot be negative.", nameof(allocationRecomendation));
            }
        }

    }
}
