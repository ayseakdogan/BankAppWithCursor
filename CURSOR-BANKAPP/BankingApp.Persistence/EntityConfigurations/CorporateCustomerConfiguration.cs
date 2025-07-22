using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BankingApp.Persistence.EntityConfigurations
{
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("CorporateCustomers");
            builder.Property(x => x.TaxNumber).HasMaxLength(20);
            builder.Property(x => x.CompanyName).HasMaxLength(100);
            builder.Property(x => x.TradeRegisterNumber).HasMaxLength(50);
            builder.Property(x => x.ContactPerson).HasMaxLength(100);
            builder.Property(x => x.Sector).HasMaxLength(50);
        }
    }
} 