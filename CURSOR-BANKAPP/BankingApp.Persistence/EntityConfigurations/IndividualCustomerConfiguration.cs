
using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BankingApp.Persistence.EntityConfigurations
{
    public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            builder.ToTable("IndividualCustomers");
            builder.Property(x => x.IdentityNumber).HasMaxLength(20);
            builder.Property(x => x.Gender).HasMaxLength(10);
            builder.Property(x => x.MaritalStatus).HasMaxLength(20);
            builder.Property(x => x.Occupation).HasMaxLength(50);
        }
    }
} 