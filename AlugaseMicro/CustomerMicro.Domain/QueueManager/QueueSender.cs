using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CustomerMicro.Domain.CommandHandlers;
using CustomerMicro.Domain.Commands;
using CustomerMicro.Domain.Interfaces;
using CustomerMicro.Domain.Services;

namespace CustomerMicro.Domain.QueueManager
{
    public class QueueSender
    {
        const string _ConnectionString = ("DefaultEndpointsProtocol=https;AccountName=alugasestorage;AccountKey=V/TZcvSSIGvLMFNGY04rDD61PK3W86de2Rgt+2YE8OZfv5jHYJZAebsMVsKgjOPfSP0/jOoSkWHExnoMkk8OxA==;EndpointSuffix=core.windows.net");
        private readonly ICustomerService _CustomerService;


        public QueueSender(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        public static void Send(CustomerCommand CustomerCommand)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(CustomerCommand.QueueName);
            queue.CreateIfNotExistsAsync().Wait();

            CloudQueueMessage message = new CloudQueueMessage(Newtonsoft.Json.JsonConvert.SerializeObject(CustomerCommand));
            queue.AddMessageAsync(message);

        }

        public async Task Receive(string queueName, Type type)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            string messageText = "";
            do
            {
                var message = await ReceiveMessageAsync(queue);

                if (message == null)
                    continue;

                messageText = message.ToString();
                try
                {
                    
                    CustomerCommandHandler obj = new CustomerCommandHandler(_CustomerService);

                    var CustomerCommand = Newtonsoft.Json.JsonConvert.DeserializeObject(messageText, type);

                    var context = obj.GetType();

                    var method = context.GetMethod("Handle", new Type[] { type });

                    method.Invoke(obj, new object[] { CustomerCommand });
                        
                }
                catch (Exception ex) { Console.WriteLine(messageText); };
                System.Threading.Thread.Sleep(1000);
            } while (true);

        }

        static async Task<string> ReceiveMessageAsync(CloudQueue theQueue)
        {
            bool exists = await theQueue.ExistsAsync();

            if (exists)
            {
                CloudQueueMessage retrievedMessage = await theQueue.GetMessageAsync();

                if (retrievedMessage != null)
                {
                    string theMessage = retrievedMessage.AsString;

                    await theQueue.DeleteMessageAsync(retrievedMessage);
                    return theMessage;
                }
            }

            return null;
        }

    }
}
