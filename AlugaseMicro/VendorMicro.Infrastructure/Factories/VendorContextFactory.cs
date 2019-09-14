using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using VendorMicro.Infrastructure.Contexts;

namespace VendorMicro.Infrastructure.Factories
{
    public class VendorContextFactory : IDesignTimeDbContextFactory<VendorContext>
    {

        public VendorContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VendorContext>();

            optionsBuilder.UseSqlServer("Server=tcp:alugasemicro.database.windows.net,1433;Initial Catalog=AlugaseMicroVendor;Persist Security Info=False;User ID=alugasemicro;Password=admin.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


            optionsBuilder.UseLazyLoadingProxies();


            return new VendorContext(optionsBuilder.Options);
        }

    }
}
