using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.Interfaces;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerService(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _CustomerRepository.ReadAll();
        }

        public void Create(Customer Customer)
        {
            Customer.Id = new Guid();
            _CustomerRepository.Create(Customer);
        }

        public void Update(Customer Customer)
        {
            _CustomerRepository.Update(Customer);
        }

        public Customer Read(Guid id)
        {
            return _CustomerRepository.Read(id);
        }

        public void Delete(Guid id)
        {
            _CustomerRepository.Delete(id);
        }

        public void Complete()
        {
            _CustomerRepository.SaveChanges();
        }
    }

}
