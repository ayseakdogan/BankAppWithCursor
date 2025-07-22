using BankingApp.Application.Services.Repositories;
using BankingApp.Persistence.Contexts;
using BankingApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BankingApp.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankingAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
            services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
            services.AddScoped(typeof(ICustomerRepository<>), typeof(CustomerRepository<>));

            return services;
        }
    }
}