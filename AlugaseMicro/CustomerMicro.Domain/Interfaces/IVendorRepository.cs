using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
    }
}
