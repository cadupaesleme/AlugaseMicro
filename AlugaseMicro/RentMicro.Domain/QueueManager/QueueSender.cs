using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RentMicro.Domain.CommandHandlers;
using RentMicro.Domain.Commands;
using RentMicro.Domain.Interfaces;
using RentMicro.Domain.Services;
using RentItemMicro.Domain.CommandHandlers;

namespace RentMicro.Domain.QueueManager
{
    public class QueueSender
    {
        const string _ConnectionString = ("DefaultEndpointsProtocol=https;AccountName=alugasestorage;AccountKey=P4il7lcfc8wdXTe1cQULpzcyp3+i+U9BkjxtJWd6e9zRd8R67aFW7RQTfLv1xp8G8M8RzqBLjMLcdNMibRFZHw==;EndpointSuffix=core.windows.net");
        private readonly IRentService _RentService;
        private readonly IRentItemService _RentItemService;


        public QueueSender(IRentService RentService, IRentItemService RentItemService)
        {
            _RentService = RentService;
            _RentItemService = RentItemService;
        }

        public static void Send(RentCommand RentCommand)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(RentCommand.QueueName);
            queue.CreateIfNotExistsAsync().Wait();

            CloudQueueMessage message = new CloudQueueMessage(Newtonsoft.Json.JsonConvert.SerializeObject(RentCommand));
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

                    RentCommandHandler objRent = new RentCommandHandler(_RentService);
                    RentItemCommandHandler objRentItem = new RentItemCommandHandler(_RentItemService);

                    var RentCommand = Newtonsoft.Json.JsonConvert.DeserializeObject(messageText, type);

                    var contextRent = objRent.GetType();
                    var contextRentItem = objRentItem.GetType();

                    var methodRent = contextRent.GetMethod("Handle", new Type[] { type });
                    var methodRentItem = contextRentItem.GetMethod("Handle", new Type[] { type });
                    if (methodRent != null)
                    {
                        methodRent.Invoke(objRent, new object[] { RentCommand });
                    }
                    else 
                    {
                        methodRentItem.Invoke(objRentItem, new object[] { RentCommand });
                    }

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
