using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.Domain.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> ReadAll();
        void Create(Customer Customer);
        void Update(Customer Customer);
        Customer Read(Guid id);
        void Delete(Guid id);
        void Complete();
    }
}
