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
using RentItemMicro.Domain.Services;
using RentItemMicro.Infrastructure.Repositories;
using RentMicro.API.AutoMapper;
using RentMicro.API.Interfaces;
using RentMicro.API.Service;
using RentMicro.Domain.CommandHandlers;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.Services;
using RentMicro.Infrastructure.Contexts;
using RentMicro.Infrastructure.Repositories;

namespace RentMicro.API
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
            services.AddScoped<IRentAppService, RentAppService>();
            services.AddScoped<IRentItemAppService, RentItemAppService>();

            //Repository
            services.AddScoped<IRentRepository, RentEntityFrameworkRepository>();
            services.AddScoped<IRentItemRepository, RentItemEntityFrameworkRepository>();

            //Service
            services.AddScoped<IRentService, RentService>();
            services.AddScoped<IRentItemService, RentItemService>();
            //AutoMapper
            services.AddAutoMapperSetup();
                       
            //services.AddDbContext<RentContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("RentConnection")));

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
