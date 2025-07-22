using AutoMapper;
using BankingApp.Application.Features.CorporateCustomers.Commands.Dtos;
using BankingApp.Application.Features.CorporateCustomers.Rules;
using BankingApp.Application.Services.Repositories;
using BankingApp.Domain.Entities;
using MediatR;

namespace BankingApp.Application.Features.CorporateCustomers.Commands
{
    public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerResponseDto>
    {
        public CreateCorporateCustomerRequestDto Request { get; set; } = new();
    }

    public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerRepository _repository;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public CreateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository repository, CorporateCustomerBusinessRules businessRules)
        {
            _mapper = mapper;
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<CreateCorporateCustomerResponseDto> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.TaxNumberCannotBeDuplicatedWhenInserted(request.Request.TaxNumber, cancellationToken);
            var entity = _mapper.Map<CorporateCustomer>(request.Request);
            await _repository.AddAsync(entity, cancellationToken);
            return _mapper.Map<CreateCorporateCustomerResponseDto>(entity);
        }
    }
} 