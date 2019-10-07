using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Interfaces
{
    public interface IRentItemRepository : IRepository<RentItem, Guid>
    {
    }
}
