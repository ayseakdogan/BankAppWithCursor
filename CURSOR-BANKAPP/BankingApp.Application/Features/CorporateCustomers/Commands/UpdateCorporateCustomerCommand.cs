using AutoMapper;
using BankingApp.Application.Features.CorporateCustomers.Commands.Dtos;
using BankingApp.Application.Features.CorporateCustomers.Rules;
using BankingApp.Application.Services.Repositories;
using BankingApp.Domain.Entities;
using FluentValidation;
using MediatR;

namespace BankingApp.Application.Features.CorporateCustomers.Commands
{
    public class UpdateCorporateCustomerCommand : IRequest<UpdateCorporateCustomerResponseDto>
    {
        public Guid Id { get; set; }
        public UpdateCorporateCustomerRequestDto Request { get; set; } = new();
    }

    public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdateCorporateCustomerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerRepository _repository;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public UpdateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository repository, CorporateCustomerBusinessRules businessRules)
        {
            _mapper = mapper;
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<UpdateCorporateCustomerResponseDto> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExistWhenRequested(request.Id, cancellationToken);
            var entity = await _repository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            _mapper.Map(request.Request, entity);
            await _repository.UpdateAsync(entity, cancellationToken);
            return _mapper.Map<UpdateCorporateCustomerResponseDto>(entity);
        }
    }

    public class UpdateCorporateCustomerCommandValidator : AbstractValidator<UpdateCorporateCustomerCommand>
    {
        public UpdateCorporateCustomerCommandValidator()
        {
            RuleFor(x => x.Request.Name).NotEmpty().WithMessage("Şirket adı boş olamaz.");
            RuleFor(x => x.Request.TaxNumber).Length(10).WithMessage("Vergi numarası 10 haneli olmalı.");
        }
    }
} 