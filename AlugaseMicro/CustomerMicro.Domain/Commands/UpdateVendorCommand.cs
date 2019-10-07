using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Customer Customer)
        {
            this.QueueName = "update-customer-command-queue";
            this.Customer = Customer;
        }
    }
}
