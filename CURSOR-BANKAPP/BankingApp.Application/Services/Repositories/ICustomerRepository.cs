using BankingApp.Core.Repositories;
using BankingApp.Domain.Entities;

namespace BankingApp.Application.Services.Repositories
{
    public interface ICustomerRepository<T> : IAsyncRepository<T, Guid> where T : Customer
    {
        // Customer'a özel ek metotlar buraya eklenebilir
    }
} 