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
using CustomerMicro.API.AutoMapper;
using CustomerMicro.API.Interfaces;
using CustomerMicro.API.Service;
using CustomerMicro.Domain.CommandHandlers;
using CustomerMicro.Domain.Interfaces;
using CustomerMicro.Domain.Services;
using CustomerMicro.Infrastructure.Contexts;
using CustomerMicro.Infrastructure.Repositories;

namespace CustomerMicro.API
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
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            //Repository
            services.AddScoped<ICustomerRepository, CustomerEntityFrameworkRepository>();

            //Service
            services.AddScoped<ICustomerService, CustomerService>();

            //AutoMapper
            services.AddAutoMapperSetup();
                       
            //services.AddDbContext<CustomerContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("CustomerConnection")));

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
