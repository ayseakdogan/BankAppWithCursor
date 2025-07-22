using AutoMapper;
using BankingApp.Application.Features.IndividualCustomers.Commands.Dtos;
using BankingApp.Application.Features.IndividualCustomers.Rules;
using BankingApp.Application.Services.Repositories;
using BankingApp.Domain.Entities;
using FluentValidation;
using MediatR;

namespace BankingApp.Application.Features.IndividualCustomers.Commands
{
    public class UpdateIndividualCustomerCommand : IRequest<UpdateIndividualCustomerResponseDto>
    {
        public Guid Id { get; set; }
        public UpdateIndividualCustomerRequestDto Request { get; set; } = new();
    }

    public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _repository;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public UpdateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository repository, IndividualCustomerBusinessRules businessRules)
        {
            _mapper = mapper;
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<UpdateIndividualCustomerResponseDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExistWhenRequested(request.Id, cancellationToken);
            var entity = await _repository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            _mapper.Map(request.Request, entity);
            await _repository.UpdateAsync(entity, cancellationToken);
            return _mapper.Map<UpdateIndividualCustomerResponseDto>(entity);
        }
    }

    public class UpdateIndividualCustomerCommandValidator : AbstractValidator<UpdateIndividualCustomerCommand>
    {
        public UpdateIndividualCustomerCommandValidator()
        {
            RuleFor(x => x.Request.Name).NotEmpty().WithMessage("İsim boş olamaz.");
            RuleFor(x => x.Request.IdentityNumber).Length(11).WithMessage("Kimlik numarası 11 haneli olmalı.");
        }
    }
} 