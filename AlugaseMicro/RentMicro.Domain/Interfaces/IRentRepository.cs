using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Domain.Interfaces
{
    public interface IRentRepository : IRepository<Rent, Guid>
    {
    }
}
