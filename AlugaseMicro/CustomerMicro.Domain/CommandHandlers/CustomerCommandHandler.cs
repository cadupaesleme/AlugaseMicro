using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.Commands;
using CustomerMicro.Domain.Interfaces;

namespace CustomerMicro.Domain.CommandHandlers
{
    public class CustomerCommandHandler
    {
        private readonly ICustomerService _CustomerService;

        public CustomerCommandHandler(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        public void Handle(CreateCustomerCommand command)
        {
            _CustomerService.Create(command.Customer);
            _CustomerService.Complete();
        }

        public void Handle(UpdateCustomerCommand command)
        {
            _CustomerService.Update(command.Customer);
            _CustomerService.Complete();
        }

        public void Handle(DeleteCustomerCommand command)
        {
            _CustomerService.Delete(command.Id);
            _CustomerService.Complete();
        }
    }
}
