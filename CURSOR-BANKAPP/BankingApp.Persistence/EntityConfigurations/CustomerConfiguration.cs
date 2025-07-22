using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(200);
            builder.UseTptMappingStrategy();
        }
    }
} 