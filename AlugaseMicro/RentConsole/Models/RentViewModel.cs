using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentConsole
{
    public class Rent
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public String Date { get; set; }
        public List<RentItem> RentItens { get; set; }
    }
}
