using BankingApp.Application.Features.CorporateCustomers.Constants;
using BankingApp.Application.Services.Repositories;
using BankingApp.Core.CrossCuttingConcerns.Exceptions.Types;


namespace BankingApp.Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }

        public async Task TaxNumberCannotBeDuplicatedWhenInserted(string taxNumber, CancellationToken cancellationToken)
        {
            var result = await _corporateCustomerRepository.AnyAsync(x => x.TaxNumber == taxNumber, cancellationToken: cancellationToken);
            if (result)
                throw new BusinessException(CorporateCustomerMessages.TaxNumberAlreadyExists);
        }

        public async Task CustomerShouldExistWhenRequested(Guid id, CancellationToken cancellationToken)
        {
            var result = await _corporateCustomerRepository.GetAsync(x => x.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                throw new BusinessException(CorporateCustomerMessages.CustomerNotFound);
        }
    }
} 