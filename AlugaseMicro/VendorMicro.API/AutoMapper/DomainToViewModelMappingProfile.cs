using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicro.API.Models;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Vendor, VendorViewModel>();
        }
    }
}
