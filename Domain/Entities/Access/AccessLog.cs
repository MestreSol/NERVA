using Domain.Common;

namespace Domain.Entities.Access
{
    // Classe que representa um log de acesso
    public class AccessLog : BaseEntity
    {
        // Propriedades do log de acesso
        public Employee.Employee Employee { get; set; } // Funcionário associado ao log
        public Guid EmployeeId { get; set; } // ID do funcionário
        public string Resource { get; set; } // Recurso acessado
        public string Action { get; set; } // Ação realizada
        public bool IsSuccess { get; set; } // Indica se a ação foi bem-sucedida
        public string IpAddress { get; set; } // Endereço IP do acesso
        public DateTimeOffset Timestamp { get; set; } // Data e hora do acesso

        // Método para validar as propriedades do log
        public void IsValid()
        {
            // Valida o recurso
            ValidateString(Resource, 1000, nameof(Resource));
            // Valida a ação
            ValidateString(Action, 1000, nameof(Action));
            // Valida o endereço IP
            ValidateString(IpAddress, 45, nameof(IpAddress));
            // Valida o funcionário
            if (Employee == null)
                throw new ArgumentNullException(nameof(Employee), "Employee cannot be null.");
            // Valida o ID do funcionário
            if (EmployeeId == Guid.Empty)
                throw new ArgumentException("EmployeeId must be a valid GUID.", nameof(EmployeeId));
            // Valida o timestamp
            if (Timestamp == default)
                throw new ArgumentException("Timestamp must be a valid DateTimeOffset.", nameof(Timestamp));
        }

        // Método auxiliar para validar strings
        private void ValidateString(string value, int maxLength, string paramName)
        {
            if (string.IsNullOrEmpty(value) || value.Length > maxLength)
                throw new ArgumentException($"{paramName} must be a non-empty string with a maximum length of {maxLength} characters.", paramName);
        }

        // Construtor da classe AccessLog
        public AccessLog(Employee.Employee employee, string resources, string actions, bool isSuccess, string ipAddress)
        {
            Timestamp = DateTimeOffset.UtcNow; // Define o timestamp atual
            Employee = employee ?? throw new ArgumentNullException(nameof(employee), "Employee cannot be null."); // Define o funcionário
            EmployeeId = employee.Id; // Define o ID do funcionário
            Resource = resources; // Define o recurso
            Action = actions; // Define a ação
            IsSuccess = isSuccess; // Define se a ação foi bem-sucedida
            IpAddress = ipAddress; // Define o endereço IP
            IsValid(); // Valida as propriedades
        }
    }
}
