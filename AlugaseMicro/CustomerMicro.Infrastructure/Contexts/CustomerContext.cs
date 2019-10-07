using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Domain.CustomerAggregate;

namespace CustomerMicro.Infrastructure.Contexts
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}