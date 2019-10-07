using System;
using System.Collections.Generic;
using System.Text;

namespace RentMicro.Domain.Commands
{
    public class DeleteRentCommand : RentCommand
    {
        public Guid Id { get; private set; }

        public DeleteRentCommand(Guid Id)
        {
            this.QueueName = "delete-rent-command-queue";
            this.Id = Id;
        }
    }
}
