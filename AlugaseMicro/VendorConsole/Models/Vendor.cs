using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorConsole
{
    public class Vendor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }
        public string Bithday { get; set; }
        public string Gender { get; set; }
    }
}
