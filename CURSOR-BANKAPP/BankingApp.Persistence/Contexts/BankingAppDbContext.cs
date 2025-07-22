using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Persistence.Contexts
{
    public class BankingAppDbContext : DbContext
    {
        public BankingAppDbContext(DbContextOptions<BankingAppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<IndividualCustomer> IndividualCustomers => Set<IndividualCustomer>();
        public DbSet<CorporateCustomer> CorporateCustomers => Set<CorporateCustomer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankingAppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
} 