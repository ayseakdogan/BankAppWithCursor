using BankingApp.Domain.Entities;

namespace BankingApp.Application.Services.Repositories
{
    public interface IIndividualCustomerRepository : ICustomerRepository<IndividualCustomer>
    {
        // IndividualCustomer'a özel ek metotlar buraya eklenebilir
    }
} 