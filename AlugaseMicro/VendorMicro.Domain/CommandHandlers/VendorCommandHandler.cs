using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.Commands;
using VendorMicro.Domain.Interfaces;

namespace VendorMicro.Domain.CommandHandlers
{
    public class VendorCommandHandler
    {
        private readonly IVendorService _vendorService;

        public VendorCommandHandler(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public void Handle(CreateVendorCommand command)
        {
            _vendorService.Create(command.Vendor);
            _vendorService.Complete();
        }

        public void Handle(UpdateVendorCommand command)
        {
            _vendorService.Update(command.Vendor);
            _vendorService.Complete();
        }

        public void Handle(DeleteVendorCommand command)
        {
            _vendorService.Delete(command.Id);
            _vendorService.Complete();
        }
    }
}
