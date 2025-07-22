namespace BankingApp.Domain.Entities
{
    public class CorporateCustomer : Customer
    {
        public string TaxNumber { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string TradeRegisterNumber { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public int NumberOfEmployees { get; set; }
        public decimal AnnualTurnover { get; set; }
    }
} 