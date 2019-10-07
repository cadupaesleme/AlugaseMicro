using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentMicro.API.Interfaces;
using RentMicro.API.Models;
using RentMicro.Domain.Commands;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.QueueManager;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.API.Service
{
    public class RentItemAppService : IRentItemAppService
    {
        private readonly IMapper _mapper;
        private readonly IRentItemService _RentItemService;


        public RentItemAppService(IMapper mapper, IRentItemService RentItemService)
        {
            _mapper = mapper;
            _RentItemService = RentItemService;
        }

        public void Create(RentItemViewModel RentItemViewModel)
        {
            CreateRentCommand createRentCommand = new CreateRentCommand(_mapper.Map<Rent>(RentItemViewModel));
            QueueSender.Send(createRentCommand);
        }

        public void Delete(Guid id)
        {
            DeleteRentItemCommand deleteRentItemCommand = new DeleteRentItemCommand(id);
            QueueSender.Send(deleteRentItemCommand);
        }

        public void Update(RentItemViewModel RentItemViewModel)
        {
            UpdateRentItemCommand updateRentItemCommand = new UpdateRentItemCommand(_mapper.Map<RentItem>(RentItemViewModel));
            QueueSender.Send(updateRentItemCommand);
        }

        public RentItemViewModel Read(Guid id)
        {
            return _mapper.Map<RentItemViewModel>(_RentItemService.Read(id));
        }

        public IEnumerable<RentItemViewModel> ReadAll()
        {
            return _mapper.Map<IEnumerable<RentItemViewModel>>(_RentItemService.ReadAll());
        }        
    }
}
