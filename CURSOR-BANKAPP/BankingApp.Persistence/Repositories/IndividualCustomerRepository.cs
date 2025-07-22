using BankingApp.Application.Services.Repositories;
using BankingApp.Domain.Entities;
using BankingApp.Persistence.Contexts;

namespace BankingApp.Persistence.Repositories
{
    public class IndividualCustomerRepository : CustomerRepository<IndividualCustomer>, IIndividualCustomerRepository
    {
        public IndividualCustomerRepository(BankingAppDbContext context) : base(context) { }
    }
} 