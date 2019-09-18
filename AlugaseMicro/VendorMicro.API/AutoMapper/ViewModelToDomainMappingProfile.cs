using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicro.API.Models;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VendorViewModel, Vendor>();
        }
    }
}
