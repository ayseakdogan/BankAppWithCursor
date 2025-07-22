using BankingApp.Application.Services.Repositories;
using BankingApp.Core.Repositories;
using BankingApp.Domain.Entities;
using BankingApp.Persistence.Contexts;

namespace BankingApp.Persistence.Repositories
{
    public class CustomerRepository<T> : EFRepositoryBase<T, Guid, BankingAppDbContext>, ICustomerRepository<T> where T : Customer
    {
        public CustomerRepository(BankingAppDbContext context) : base(context) { }
    }
} 