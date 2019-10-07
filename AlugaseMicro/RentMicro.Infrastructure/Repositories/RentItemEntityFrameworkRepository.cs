using System;
using System.Collections.Generic;
using System.Text;
using RentItemMicro.Infrastructure.Factories;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.RentAggregate;
using RentMicro.Infrastructure.Contexts;
using RentMicro.Infrastructure.Factories;

namespace RentItemMicro.Infrastructure.Repositories
{
    public class RentItemEntityFrameworkRepository : IRentItemRepository
    {
        private readonly RentItemContext _db;

        public RentItemEntityFrameworkRepository()
        {
            _db = new RentItemContextFactory().CreateDbContext(null);
        }

        //public RentItemEntityFrameworkRepository(RentItemContext RentItemContext)
        //{
        //    _db = RentItemContext;
        //}

        public void Create(RentItem entity)
        {
            _db.RentItem.Add(entity);
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
        }

        public RentItem Read(Guid id)
        {
            return _db.RentItem.Find(id);
        }

        public IEnumerable<RentItem> ReadAll()
        {
            return _db.RentItem;
        }

        public void Update(RentItem entity)
        {
            _db.RentItem.Update(entity);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
