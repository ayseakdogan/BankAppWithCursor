using BankingApp.Application.Features.IndividualCustomers.Constants;
using BankingApp.Application.Services.Repositories;
using BankingApp.Domain.Entities;
using BankingApp.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankingApp.Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task NationalIdCannotBeDuplicatedWhenInserted(string identityNumber, CancellationToken cancellationToken)
        {
            var result = await _individualCustomerRepository.AnyAsync(x => x.IdentityNumber == identityNumber, cancellationToken: cancellationToken);
            if (result)
                throw new BusinessException(IndividualCustomerMessages.NationalIdAlreadyExists);
        }

        public async Task CustomerShouldExistWhenRequested(Guid id, CancellationToken cancellationToken)
        {
            var result = await _individualCustomerRepository.GetAsync(x => x.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                throw new BusinessException(IndividualCustomerMessages.CustomerNotFound);
        }
    }
} 