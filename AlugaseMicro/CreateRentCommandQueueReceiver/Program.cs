using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentMicro.Domain.CommandHandlers;
using RentMicro.Domain.Commands;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.QueueManager;
using RentMicro.Domain.Services;
using RentMicro.Infrastructure.Repositories;
using RentItemMicro.Domain.Services;
using RentItemMicro.Infrastructure.Repositories;

namespace CreateRentCommandQueueReceiver
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();

                
            tasks.Add(AwakeReceive("create-rent-command-queue", typeof(CreateRentCommand)));
            tasks.Add(AwakeReceive("update-rent-command-queue", typeof(UpdateRentItemCommand)));
            tasks.Add(AwakeReceive("delete-rent-command-queue", typeof(DeleteRentItemCommand)));

            Task.WaitAll(tasks.ToArray());

        }

        private static async Task AwakeReceive(string queueName, Type type)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IRentService, RentService>();
            collection.AddScoped<IRentItemService, RentItemService>();
            collection.AddScoped<IRentRepository, RentEntityFrameworkRepository>();
            collection.AddScoped<IRentItemRepository, RentItemEntityFrameworkRepository>();

            var serviceProvider = collection.BuildServiceProvider();
            var serviceRent = serviceProvider.GetService<IRentService>();
            var serviceRentItem = serviceProvider.GetService<IRentItemService>();

            var queueSender = new QueueSender(serviceRent, serviceRentItem);

            await queueSender.Receive(queueName, type);

        }

    }
}
