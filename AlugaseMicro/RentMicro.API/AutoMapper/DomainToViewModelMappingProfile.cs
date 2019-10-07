using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentMicro.API.Models;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Rent, RentViewModel>();
            CreateMap<RentItem, RentItemViewModel>();
        }
    }
}
