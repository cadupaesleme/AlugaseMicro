using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerMicro.Domain.Commands
{
    public class DeleteCustomerCommand : CustomerCommand
    {
        public Guid Id { get; private set; }

        public DeleteCustomerCommand(Guid Id)
        {
            this.QueueName = "delete-customer-command-queue";
            this.Id = Id;
        }
    }
}
