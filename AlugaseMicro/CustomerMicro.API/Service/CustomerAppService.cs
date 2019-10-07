using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicro.API.Interfaces;
using CustomerMicro.API.Models;
using CustomerMicro.Domain.Commands;
using CustomerMicro.Domain.Interfaces;
using CustomerMicro.Domain.QueueManager;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.API.Service
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _CustomerService;


        public CustomerAppService(IMapper mapper, ICustomerService CustomerService)
        {
            _mapper = mapper;
            _CustomerService = CustomerService;
        }

        public void Create(CustomerViewModel CustomerViewModel)
        {
            CreateCustomerCommand createCustomerCommand = new CreateCustomerCommand(_mapper.Map<Customer>(CustomerViewModel));
            QueueSender.Send(createCustomerCommand);
        }

        public void Delete(Guid id)
        {
            DeleteCustomerCommand deleteCustomerCommand = new DeleteCustomerCommand(id);
            QueueSender.Send(deleteCustomerCommand);
        }

        public void Update(CustomerViewModel CustomerViewModel)
        {
            UpdateCustomerCommand updateCustomerCommand = new UpdateCustomerCommand(_mapper.Map<Customer>(CustomerViewModel));
            QueueSender.Send(updateCustomerCommand);
        }

        public CustomerViewModel Read(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_CustomerService.Read(id));
        }

        public IEnumerable<CustomerViewModel> ReadAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(_CustomerService.ReadAll());
        }        
    }
}
