using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicro.API.Interfaces;
using VendorMicro.API.Models;
using VendorMicro.Domain.Commands;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Domain.QueueManager;
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
            CreateVendorCommand createVendorCommand = new CreateVendorCommand(_mapper.Map<Vendor>(vendorViewModel));
            QueueSender.Send(createVendorCommand);
        }

        public void Delete(Guid id)
        {
            DeleteVendorCommand deleteVendorCommand = new DeleteVendorCommand(id);
            QueueSender.Send(deleteVendorCommand);
        }

        public void Update(VendorViewModel vendorViewModel)
        {
            UpdateVendorCommand updateVendorCommand = new UpdateVendorCommand(_mapper.Map<Vendor>(vendorViewModel));
            QueueSender.Send(updateVendorCommand);
        }

        public VendorViewModel Read(Guid id)
        {
            return _mapper.Map<VendorViewModel>(_vendorService.Read(id));
        }

        public IEnumerable<VendorViewModel> ReadAll()
        {
            return _mapper.Map<IEnumerable<VendorViewModel>>(_vendorService.ReadAll());
        }        
    }
}
