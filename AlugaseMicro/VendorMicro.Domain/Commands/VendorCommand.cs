using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.Domain.Commands
{
    public abstract class VendorCommand
    {
        public Vendor Vendor { get; protected set; }
        public string QueueName { get; protected set; }
    }
}
