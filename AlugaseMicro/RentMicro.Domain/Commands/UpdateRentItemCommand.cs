using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Commands
{
    public class UpdateRentItemCommand : RentCommand
    {
        public UpdateRentItemCommand(RentItem RentItem)
        {
            this.QueueName = "update-rent-command-queue";
            this.RentItem = RentItem;
        }      
    }
}
