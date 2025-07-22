using BankingApp.Application.Features.IndividualCustomers.Rules;
using BankingApp.Application.Services.Repositories;
using MediatR;

namespace BankingApp.Application.Features.IndividualCustomers.Commands
{
    public class DeleteIndividualCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, bool>
    {
        private readonly IIndividualCustomerRepository _repository;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository repository, IndividualCustomerBusinessRules businessRules)
        {
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<bool> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExistWhenRequested(request.Id, cancellationToken);
            var entity = await _repository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            await _repository.DeleteAsync(entity!, cancellationToken: cancellationToken);
            return true;
        }
    }
}
