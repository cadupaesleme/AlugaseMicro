using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Interfaces
{
    public interface IRentItemService
    {
        IEnumerable<RentItem> ReadAll();
        void Create(RentItem Rent);
        void Update(RentItem Rent);
        RentItem Read(Guid id);
        void Delete(Guid id);
        void Complete();
    }
}
