namespace BankingApp.Application.Features.IndividualCustomers.Commands.Dtos
{
    public class UpdateIndividualCustomerResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public decimal MonthlyIncome { get; set; }
        public string Occupation { get; set; } = string.Empty;
    }
} 