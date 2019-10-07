using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.Commands;
using RentMicro.Domain.Interfaces;

namespace RentMicro.Domain.CommandHandlers
{
    public class RentCommandHandler
    {
        private readonly IRentService _RentService;

        public RentCommandHandler(IRentService RentService)
        {
            _RentService = RentService;
        }

        public void Handle(CreateRentCommand command)
        {
            _RentService.Create(command.Rent);
            _RentService.Complete();
        }

        public void Handle(UpdateRentCommand command)
        {
            _RentService.Update(command.Rent);
            _RentService.Complete();
        }

        public void Handle(DeleteRentCommand command)
        {
            _RentService.Delete(command.Id);
            _RentService.Complete();
        }
    }
}
