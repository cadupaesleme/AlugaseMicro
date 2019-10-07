using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMicro.API.Models
{
    public class RentItemViewModel
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public String InitialDate { get; set; }
        public String EndDate { get; set; }
    }
}
