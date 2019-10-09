using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMicro.API.Models
{
    public class RentViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public String Date { get; set; }
        public List<RentItemViewModel> RentItens { get; set; }
    }
}
