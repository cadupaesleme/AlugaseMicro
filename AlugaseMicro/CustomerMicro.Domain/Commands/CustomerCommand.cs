using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.Domain.Commands
{
    public class CustomerCommand
    {
        public Customer Customer { get; protected set; }
        public string QueueName { get; protected set; }
    }
}
