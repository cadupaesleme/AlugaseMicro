﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendorMicro.Domain.VendorAggregate
{
    public class Vendor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }
    }
}
