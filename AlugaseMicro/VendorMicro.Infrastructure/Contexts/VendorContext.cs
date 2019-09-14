using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Domain.VendorAggregate;

namespace VendorMicro.Infrastructure.Contexts
{
    public class VendorContext : DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }

        public VendorContext(DbContextOptions<VendorContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}