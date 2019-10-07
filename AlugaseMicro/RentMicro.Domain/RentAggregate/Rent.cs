using System;
using System.Collections.Generic;
using System.Text;

namespace RentMicro.Domain.RentAggregate
{
    public class Rent
    {
        public Guid Id { get; set; }
        public String Date { get; set; }
        public virtual List<RentItem> RentItens { get; set; }
    }
}
