using AutoMapper;
using DemoApi.Application.Dto;
using DemoApi.Application.Service.Commands;
using DemoApi.Application.Service.Queries;
using DemoApi.Domain.Repository;
using DemoApi.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ForMember(des => des.Customer, act => act.MapFrom(src => src.Customer)).ReverseMap();
            CreateMap<Account, CreateAccountCommand>().ForMember(des => des.Customer, act => act.MapFrom(src => src.Customer)).ReverseMap();
            CreateMap<Account, UpdateAccountCommand>().ReverseMap();
            CreateMap<Account, GetAccountByIdCommand>().ReverseMap();
            //CreateMap<Account, >


            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
