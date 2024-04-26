using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Northwind.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {

            CreateMap<Models.Customers, Models.CustomerDto>()
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName ?? string.Empty))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address ?? string.Empty))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City ?? string.Empty))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country ?? string.Empty));

            CreateMap<Models.CustomerUpdateDto, Models.Customers>();
            CreateMap<Models.Customers, Models.CustomerUpdateDto>();
            CreateMap<Models.Customers, Models.CustomerDetailDto>();
            CreateMap<Models.CustomerCreateDto, Models.Customers>();
        }
    }
}