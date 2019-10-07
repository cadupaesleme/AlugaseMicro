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
    public class RentAppService : IRentAppService
    {
        private readonly IMapper _mapper;
        private readonly IRentService _RentService;


        public RentAppService(IMapper mapper, IRentService RentService)
        {
            _mapper = mapper;
            _RentService = RentService;
        }

        public void Create(RentViewModel RentViewModel)
        {
            CreateRentCommand createRentCommand = new CreateRentCommand(_mapper.Map<Rent>(RentViewModel));
            QueueSender.Send(createRentCommand);
        }

        public void Delete(Guid id)
        {
            DeleteRentCommand deleteRentCommand = new DeleteRentCommand(id);
            QueueSender.Send(deleteRentCommand);
        }

        public void Update(RentViewModel RentViewModel)
        {
            UpdateRentCommand updateRentCommand = new UpdateRentCommand(_mapper.Map<Rent>(RentViewModel));
            QueueSender.Send(updateRentCommand);
        }

        public RentViewModel Read(Guid id)
        {
            return _mapper.Map<RentViewModel>(_RentService.Read(id));
        }

        public IEnumerable<RentViewModel> ReadAll()
        {
            return _mapper.Map<IEnumerable<RentViewModel>>(_RentService.ReadAll());
        }        
    }
}
