using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerMicro.Domain.CommandHandlers;
using CustomerMicro.Domain.Commands;
using CustomerMicro.Domain.Interfaces;
using CustomerMicro.Domain.QueueManager;
using CustomerMicro.Domain.Services;
using CustomerMicro.Infrastructure.Repositories;

namespace CreateCustomerCommandQueueReceiver
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();

                
            tasks.Add(AwakeReceive("create-customer-command-queue", typeof(CreateCustomerCommand)));
            tasks.Add(AwakeReceive("update-customer-command-queue", typeof(UpdateCustomerCommand)));
            tasks.Add(AwakeReceive("delete-customer-command-queue", typeof(DeleteCustomerCommand)));

            Task.WaitAll(tasks.ToArray());

        }

        private static async Task AwakeReceive(string queueName, Type type)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ICustomerService, CustomerService>();
            collection.AddScoped<ICustomerRepository, CustomerEntityFrameworkRepository>();

            var serviceProvider = collection.BuildServiceProvider();
            var service = serviceProvider.GetService<ICustomerService>();

            var queueSender = new QueueSender(service);

            await queueSender.Receive(queueName, type);

        }

    }
}
