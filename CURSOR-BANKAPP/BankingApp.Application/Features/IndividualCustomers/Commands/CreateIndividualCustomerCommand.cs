using AutoMapper;
using BankingApp.Application.Features.IndividualCustomers.Commands.Dtos;
using BankingApp.Application.Features.IndividualCustomers.Rules;
using BankingApp.Application.Services.Repositories;
using BankingApp.Domain.Entities;
using MediatR;

namespace BankingApp.Application.Features.IndividualCustomers.Commands
{
    public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponseDto>
    {
        public CreateIndividualCustomerRequestDto Request { get; set; } = new();
    }

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _repository;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository repository, IndividualCustomerBusinessRules businessRules)
        {
            _mapper = mapper;
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerResponseDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(request.Request.IdentityNumber, cancellationToken);
            var entity = _mapper.Map<IndividualCustomer>(request.Request);
            await _repository.AddAsync(entity, cancellationToken);
            return _mapper.Map<CreateIndividualCustomerResponseDto>(entity);
        }
    }
} 