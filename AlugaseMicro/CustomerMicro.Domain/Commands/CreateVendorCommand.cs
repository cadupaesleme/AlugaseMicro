using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.Domain.Commands
{
    public class CreateCustomerCommand : CustomerCommand
    {   
        public CreateCustomerCommand(Customer Customer)
        {
            this.QueueName = "create-customer-command-queue";
            this.Customer = Customer;
        }
    }
}
