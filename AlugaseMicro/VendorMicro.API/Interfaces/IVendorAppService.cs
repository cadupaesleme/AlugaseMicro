using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicro.API.Models;

namespace VendorMicro.API.Interfaces
{
    public interface IVendorAppService
    {
        IEnumerable<VendorViewModel> ReadAll();
        VendorViewModel Read(Guid id);
        void Update(VendorViewModel vendorViewModel);
        void Delete(Guid id);
        void Create(VendorViewModel vendorViewModel);
    }
}
