namespace BankingApp.Domain.Entities
{
    public class IndividualCustomer : Customer
    {
        public string IdentityNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public decimal MonthlyIncome { get; set; }
        public string Occupation { get; set; } = string.Empty;
    }
} 