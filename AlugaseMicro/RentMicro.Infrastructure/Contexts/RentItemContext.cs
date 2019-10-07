using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Infrastructure.Contexts
{
    public class RentItemContext : DbContext
    {
        public DbSet<RentItem> RentItem { get; set; }

        public RentItemContext(DbContextOptions<RentItemContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}