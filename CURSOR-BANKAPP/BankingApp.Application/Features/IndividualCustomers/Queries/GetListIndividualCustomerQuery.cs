﻿using AutoMapper;
using BankingApp.Application.Features.IndividualCustomers.Queries.Dtos;
using BankingApp.Application.Services.Repositories;
using BankingApp.Core.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList
{
    public class GetListIndividualCustomerQuery : IRequest<Paginate<IndividualCustomerResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, Paginate<IndividualCustomerResponse>>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public GetListIndividualCustomerQueryHandler(
                IIndividualCustomerRepository individualCustomerRepository,
                IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<IndividualCustomerResponse>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
            {
                var customers = await _individualCustomerRepository.GetListAsync(
                    index: request.PageIndex,
                    size: request.PageSize,
                    cancellationToken: cancellationToken
                );

                var response = _mapper.Map<Paginate<IndividualCustomerResponse>>(customers);
                return response;
            }
        }
    }
}