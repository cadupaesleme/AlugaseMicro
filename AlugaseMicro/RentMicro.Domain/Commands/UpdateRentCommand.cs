using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Commands
{
    public class UpdateRentCommand : RentCommand
    {
        public UpdateRentCommand(Rent Rent)
        {
            this.QueueName = "update-rent-command-queue";
            this.Rent = Rent;
        }      
    }
}
