using AutoMapper;
using BankingApp.Domain.Entities;
using BankingApp.Application.Features.CorporateCustomers.Commands.Dtos;
using BankingApp.Application.Features.CorporateCustomers.Queries.Dtos;

namespace BankingApp.Application.Features.CorporateCustomers.Profiles
{
    public class CorporateCustomerProfile : Profile
    {
        public CorporateCustomerProfile()
        {
            CreateMap<CreateCorporateCustomerRequestDto, CorporateCustomer>();
            CreateMap<CorporateCustomer, CreateCorporateCustomerResponseDto>();
            CreateMap<CorporateCustomer, GetCorporateCustomerByIdResponseDto>();
            CreateMap<UpdateCorporateCustomerRequestDto, CorporateCustomer>();
            CreateMap<CorporateCustomer, UpdateCorporateCustomerResponseDto>();
            CreateMap<CorporateCustomer, GetCorporateCustomerListItemDto>();
            CreateMap<CorporateCustomer, CorporateCustomerResponse>();
        }
    }
} 