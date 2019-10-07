using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicro.API.Models;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
