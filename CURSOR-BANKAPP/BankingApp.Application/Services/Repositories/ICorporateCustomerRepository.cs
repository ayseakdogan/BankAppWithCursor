using BankingApp.Domain.Entities;

namespace BankingApp.Application.Services.Repositories
{
    public interface ICorporateCustomerRepository : ICustomerRepository<CorporateCustomer>
    {
        // CorporateCustomer'a özel ek metotlar buraya eklenebilir
    }
} 