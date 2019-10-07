using System;
using System.Collections.Generic;
using System.Text;

namespace RentMicro.Domain.Interfaces
{
    public interface IRepository<T, EntityId>
    {
        void Create(T entity);
        T Read(EntityId id);
        IEnumerable<T> ReadAll();
        void Update(T entity);
        void Delete(EntityId id);
        void SaveChanges();
    }
}
