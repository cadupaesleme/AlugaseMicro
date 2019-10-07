using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicro.API.Models;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
