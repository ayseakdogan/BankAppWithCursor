namespace BankingApp.Application.Features.IndividualCustomers.Queries.Dtos
{
    public class IndividualCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
    }
} 