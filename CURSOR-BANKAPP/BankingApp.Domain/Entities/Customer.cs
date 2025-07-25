using BankingApp.Core.Repositories;

namespace BankingApp.Domain.Entities
{
    public abstract class Customer : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
} 