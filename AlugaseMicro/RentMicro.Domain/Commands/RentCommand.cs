using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Commands
{
    public class RentCommand
    {
        public Rent Rent { get; protected set; }
        public RentItem RentItem { get; protected set; }
        public string QueueName { get; protected set; }
    }
}
