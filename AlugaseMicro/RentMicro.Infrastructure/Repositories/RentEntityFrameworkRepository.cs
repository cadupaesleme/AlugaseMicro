using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.RentAggregate;
using RentMicro.Infrastructure.Contexts;
using RentMicro.Infrastructure.Factories;

namespace RentMicro.Infrastructure.Repositories
{
    public class RentEntityFrameworkRepository : IRentRepository
    {
        private readonly RentContext _db;

        public RentEntityFrameworkRepository()
        {
            _db = new RentContextFactory().CreateDbContext(null);
        }

        //public RentEntityFrameworkRepository(RentContext RentContext)
        //{
        //    _db = RentContext;
        //}

        public void Create(Rent entity)
        {
            _db.Rents.Add(entity);
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
        }

        public Rent Read(Guid id)
        {
            return _db.Rents.Find(id);
        }

        public IEnumerable<Rent> ReadAll()
        {
            return _db.Rents;
        }

        public void Update(Rent entity)
        {
            _db.Rents.Update(entity);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
