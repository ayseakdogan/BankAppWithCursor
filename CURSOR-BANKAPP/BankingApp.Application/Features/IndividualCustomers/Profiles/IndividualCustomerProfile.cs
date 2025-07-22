using AutoMapper;
using BankingApp.Domain.Entities;
using BankingApp.Application.Features.IndividualCustomers.Commands.Dtos;
using BankingApp.Application.Features.IndividualCustomers.Queries.Dtos;
using BankingApp.Core.Repositories;
using BankingApp.Application.Features.IndividualCustomers.Commands;

namespace BankingApp.Application.Features.IndividualCustomers.Profiles
{
    public class IndividualCustomerProfile : Profile
    {
        public IndividualCustomerProfile()
        {
            CreateMap<IndividualCustomer, CreateIndividualCustomerResponseDto>();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerResponseDto>();
            CreateMap<IndividualCustomer, IndividualCustomerResponse>();


            CreateMap<CreateIndividualCustomerRequestDto, IndividualCustomer>();
            CreateMap<UpdateIndividualCustomerRequestDto, IndividualCustomer>();


            CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Request.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Request.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Request.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Request.Address))
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.Request.IdentityNumber))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Request.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Request.Gender))
                .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.Request.MaritalStatus))
                .ForMember(dest => dest.MonthlyIncome, opt => opt.MapFrom(src => src.Request.MonthlyIncome))
                .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Request.Occupation));

            CreateMap<Paginate<IndividualCustomer>, Paginate<IndividualCustomerResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        }
    }
} 