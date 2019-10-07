using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using RentMicro.Infrastructure.Contexts;

namespace RentItemMicro.Infrastructure.Factories
{
    public class RentItemContextFactory : IDesignTimeDbContextFactory<RentItemContext>
    {

        public RentItemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RentItemContext>();
            
            optionsBuilder.UseSqlServer("Server=tcp:alugasemicro.database.windows.net,1433;Initial Catalog=AlugaseMicroRent;Persist Security Info=False;User ID=alugasemicro;Password=admin.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


            optionsBuilder.UseLazyLoadingProxies();


            return new RentItemContext(optionsBuilder.Options);
        }

    }
}
