using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.Domain.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public IEnumerable<Vendor> ReadAll()
        {
            return _vendorRepository.ReadAll();
        }

        public void Create(Vendor vendor)
        {
            _vendorRepository.Create(vendor);
        }

        public void Update(Vendor vendor)
        {
            _vendorRepository.Update(vendor);
        }

        public Vendor Read(Guid id)
        {
            return _vendorRepository.Read(id);
        }

        public void Delete(Guid id)
        {
            _vendorRepository.Delete(id);
        }

        public void Complete()
        {
            _vendorRepository.SaveChanges();
        }
    }

}
