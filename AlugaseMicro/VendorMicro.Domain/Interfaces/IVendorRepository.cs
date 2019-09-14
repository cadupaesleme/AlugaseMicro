using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.Domain.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor, Guid>
    {
    }
}
