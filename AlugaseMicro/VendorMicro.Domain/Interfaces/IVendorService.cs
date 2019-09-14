using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.Domain.Interfaces
{
    public interface IVendorService
    {
        IEnumerable<Vendor> ReadAll();
        void Create(Vendor vendor);
        void Update(Vendor vendor);
        Vendor Read(Guid id);
        void Delete(Guid id);
        void Complete();
    }
}
