using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Domain.RentAggregate;

namespace RentMicro.Infrastructure.Contexts
{
    public class RentContext : DbContext
    {
        public DbSet<Rent> Rents { get; set; }

        public RentContext(DbContextOptions<RentContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}