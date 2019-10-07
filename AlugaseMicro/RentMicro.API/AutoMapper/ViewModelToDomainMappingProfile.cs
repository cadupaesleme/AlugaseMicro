using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentMicro.API.Models;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RentViewModel, Rent>();
            CreateMap<RentItemViewModel, RentItem>();
        }
    }
}
