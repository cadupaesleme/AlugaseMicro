using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Domain.VendorAggregate;
using VendorMicro.Infrastructure.Contexts;
using VendorMicro.Infrastructure.Factories;

namespace VendorMicro.Infrastructure.Repositories
{
    public class VendorEntityFrameworkRepository : IVendorRepository
    {
        private readonly VendorContext _db;

        public VendorEntityFrameworkRepository()
        {
            _db = new VendorContextFactory().CreateDbContext(null);
        }

        //public VendorEntityFrameworkRepository(VendorContext vendorContext)
        //{
        //    _db = vendorContext;
        //}

        public void Create(Vendor entity)
        {
            _db.Vendors.Add(entity);
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
        }

        public Vendor Read(Guid id)
        {
            return _db.Vendors.Find(id);
        }

        public IEnumerable<Vendor> ReadAll()
        {
            return _db.Vendors;
        }

        public void Update(Vendor entity)
        {
            _db.Vendors.Update(entity);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
