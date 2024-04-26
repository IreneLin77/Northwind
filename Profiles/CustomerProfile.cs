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
            CreateMap<Models.Customers, Models.CustomerDto>();
            CreateMap<Models.CustomerUpdateDto, Models.Customers>();
            CreateMap<Models.Customers, Models.CustomerUpdateDto>();

        }
    }
}