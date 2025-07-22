namespace BankingApp.Application.Features.CorporateCustomers.Commands.Dtos
{
    public class UpdateCorporateCustomerRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string TradeRegisterNumber { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public int NumberOfEmployees { get; set; }
        public decimal AnnualTurnover { get; set; }
    }
} 