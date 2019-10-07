using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendorMicro.Domain.CommandHandlers;
using VendorMicro.Domain.Commands;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Domain.QueueManager;
using VendorMicro.Domain.Services;
using VendorMicro.Infrastructure.Repositories;

namespace CreateVendorCommandQueueReceiver
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();

                
            tasks.Add(AwakeReceive("create-vendor-command-queue", typeof(CreateVendorCommand)));
            tasks.Add(AwakeReceive("update-vendor-command-queue", typeof(UpdateVendorCommand)));
            tasks.Add(AwakeReceive("delete-vendor-command-queue", typeof(DeleteVendorCommand)));

            Task.WaitAll(tasks.ToArray());

        }

        private static async Task AwakeReceive(string queueName, Type type)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IVendorService, VendorService>();
            collection.AddScoped<IVendorRepository, VendorEntityFrameworkRepository>();

            var serviceProvider = collection.BuildServiceProvider();
            var service = serviceProvider.GetService<IVendorService>();

            var queueSender = new QueueSender(service);

            await queueSender.Receive(queueName, type);

        }

    }
}
