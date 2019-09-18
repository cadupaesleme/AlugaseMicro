using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VendorMicro.API.AutoMapper;
using VendorMicro.API.Interfaces;
using VendorMicro.API.Service;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Domain.Services;
using VendorMicro.Infrastructure.Contexts;
using VendorMicro.Infrastructure.Repositories;

namespace VendorMicro.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                        
            //Application
            services.AddScoped<IVendorAppService, VendorAppService>();

            //Repository
            services.AddScoped<IVendorRepository, VendorEntityFrameworkRepository>();

            //Service
            services.AddScoped<IVendorService, VendorService>();

            //AutoMapper
            services.AddAutoMapperSetup();

            //services.AddDbContext<VendorContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("VendorConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
