using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicro.API.Models;

namespace CustomerMicro.API.Interfaces
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerViewModel> ReadAll();
        CustomerViewModel Read(Guid id);
        void Update(CustomerViewModel CustomerViewModel);
        void Delete(Guid id);
        void Create(CustomerViewModel CustomerViewModel);
    }
}
