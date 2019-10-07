using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerMicro.Infrastructure.Contexts;

namespace CustomerMicro.Infrastructure.Factories
{
    public class CustomerContextFactory : IDesignTimeDbContextFactory<CustomerContext>
    {

        public CustomerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();

            optionsBuilder.UseSqlServer("Server=tcp:alugasemicro.database.windows.net,1433;Initial Catalog=AlugaseMicroCustomer;Persist Security Info=False;User ID=alugasemicro;Password=admin.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


            optionsBuilder.UseLazyLoadingProxies();


            return new CustomerContext(optionsBuilder.Options);
        }

    }
}
