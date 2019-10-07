using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Commands
{
    public class CreateRentCommand : RentCommand
    {   
        public CreateRentCommand(Rent Rent)
        {
            this.QueueName = "create-rent-command-queue";
            this.Rent = Rent;
        }
    }
}
