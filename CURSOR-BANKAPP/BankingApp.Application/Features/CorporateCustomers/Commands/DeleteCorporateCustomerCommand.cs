using BankingApp.Application.Features.CorporateCustomers.Rules;
using BankingApp.Application.Services.Repositories;
using MediatR;

namespace BankingApp.Application.Features.CorporateCustomers.Commands
{
    public class DeleteCorporateCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, bool>
    {
        private readonly ICorporateCustomerRepository _repository;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository repository, CorporateCustomerBusinessRules businessRules)
        {
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<bool> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExistWhenRequested(request.Id, cancellationToken);
            var entity = await _repository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            await _repository.DeleteAsync(entity!, cancellationToken: cancellationToken);
            return true;
        }
    }
} 