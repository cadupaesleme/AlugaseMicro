using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Interfaces
{
    public interface IRentService
    {
        IEnumerable<Rent> ReadAll();
        void Create(Rent Rent);
        void Update(Rent Rent);
        Rent Read(Guid id);
        void Delete(Guid id);
        void Complete();
    }
}
