namespace BankingApp.Application.Features.CorporateCustomers.Queries.Dtos
{
    public class CorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
    }
} 