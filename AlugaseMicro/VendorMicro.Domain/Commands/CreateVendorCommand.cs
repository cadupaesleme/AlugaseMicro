using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.Domain.Commands
{
    public class CreateVendorCommand : VendorCommand
    {   
        public CreateVendorCommand(Vendor Vendor)
        {
            this.QueueName = "create-vendor-command-queue";
            this.Vendor = Vendor;
        }
    }
}
