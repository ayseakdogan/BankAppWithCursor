using BankingApp.Application.Services.Repositories;
using BankingApp.Domain.Entities;
using BankingApp.Persistence.Contexts;

namespace BankingApp.Persistence.Repositories
{
    public class CorporateCustomerRepository : CustomerRepository<CorporateCustomer>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(BankingAppDbContext context) : base(context) { }
    }
} 