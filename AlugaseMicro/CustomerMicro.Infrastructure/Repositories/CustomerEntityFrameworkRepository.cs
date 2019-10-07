using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.Interfaces;
using CustomerMicro.Domain.CustomerAggregate;
using CustomerMicro.Infrastructure.Contexts;
using CustomerMicro.Infrastructure.Factories;

namespace CustomerMicro.Infrastructure.Repositories
{
    public class CustomerEntityFrameworkRepository : ICustomerRepository
    {
        private readonly CustomerContext _db;

        public CustomerEntityFrameworkRepository()
        {
            _db = new CustomerContextFactory().CreateDbContext(null);
        }

        //public CustomerEntityFrameworkRepository(CustomerContext CustomerContext)
        //{
        //    _db = CustomerContext;
        //}

        public void Create(Customer entity)
        {
            _db.Customers.Add(entity);
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
        }

        public Customer Read(Guid id)
        {
            return _db.Customers.Find(id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _db.Customers;
        }

        public void Update(Customer entity)
        {
            _db.Customers.Update(entity);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
