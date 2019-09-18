using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.Domain.Commands
{
    public class UpdateVendorCommand : VendorCommand
    {
        public UpdateVendorCommand(Vendor Vendor)
        {
            this.QueueName = "update-vendor-command-queue";
            this.Vendor = Vendor;
        }
    }
}
