using System;
using System.Collections.Generic;
using System.Text;

namespace VendorMicro.Domain.Commands
{
    public class DeleteVendorCommand : VendorCommand
    {
        public Guid Id { get; private set; }

        public DeleteVendorCommand(Guid Id)
        {
            this.QueueName = "delete-vendor-command-queue";
            this.Id = Id;
        }
    }
}
