using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicro.API.Interfaces;
using VendorMicro.API.Models;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.API.Service
{
    public class VendorAppService : IVendorAppService
    {
        private readonly IMapper _mapper;
        private readonly IVendorService _vendorService;


        public VendorAppService(IMapper mapper, IVendorService vendorService)
        {
            _mapper = mapper;
            _vendorService = vendorService;
        }

        public void Create(VendorViewModel vendorViewModel)
        {
            _vendorService.Create(_mapper.Map<Vendor>(vendorViewModel));
            _vendorService.Complete();
        }

        public void Delete(Guid id)
        {
            _vendorService.Delete(id);
            _vendorService.Complete();
        }

        public VendorViewModel Read(Guid id)
        {
            return _mapper.Map<VendorViewModel>(_vendorService.Read(id));
        }

        public IEnumerable<VendorViewModel> ReadAll()
        {
            return _mapper.Map<IEnumerable<VendorViewModel>>(_vendorService.ReadAll());
        }

        public void Update(VendorViewModel vendorViewModel)
        {
            _vendorService.Update(_mapper.Map<Vendor>(vendorViewModel));
            _vendorService.Complete();
        }
    }
}
