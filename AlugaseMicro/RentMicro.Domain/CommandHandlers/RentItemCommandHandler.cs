using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.Commands;
using RentMicro.Domain.Interfaces;

namespace RentItemMicro.Domain.CommandHandlers
{
    public class RentItemCommandHandler
    {
        private readonly IRentItemService _RentItemService;

        public RentItemCommandHandler(IRentItemService RentItemService)
        {
            _RentItemService = RentItemService;
        }

        //public void Handle(CreateRentItemCommand command)
        //{
        //    _RentItemService.Create(command.RentItem);
        //    _RentItemService.Complete();
        //}

        public void Handle(UpdateRentItemCommand command)
        {
            _RentItemService.Update(command.RentItem);
            _RentItemService.Complete();
        }

        public void Handle(DeleteRentItemCommand command)
        {
            _RentItemService.Delete(command.Id);
            _RentItemService.Complete();
        }
    }
}
