using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendorMicro.Domain.CommandHandlers;
using VendorMicro.Domain.Commands;
using VendorMicro.Domain.Services;

namespace VendorMicro.Domain.QueueManager
{
    public class QueueSender
    {
        const string _ConnectionString = ("DefaultEndpointsProtocol=https;AccountName=alugasestorage;AccountKey=P4il7lcfc8wdXTe1cQULpzcyp3+i+U9BkjxtJWd6e9zRd8R67aFW7RQTfLv1xp8G8M8RzqBLjMLcdNMibRFZHw==;EndpointSuffix=core.windows.net");
        private readonly IVendorCommandHandler _vendorCommandHandler;


        //public QueueSender(IVendorCommandHandler vendorCommandHandler)
        //{
        //    _vendorCommandHandler = vendorCommandHandler;
        //}

        public static void Send(VendorCommand vendorCommand)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(vendorCommand.QueueName);
            queue.CreateIfNotExistsAsync().Wait();

            CloudQueueMessage message = new CloudQueueMessage(Newtonsoft.Json.JsonConvert.SerializeObject(vendorCommand));
            queue.AddMessageAsync(message);

        }

        public static async void Receive(string queueName)
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
                    //var vendorCommand = Newtonsoft.Json.JsonConvert.DeserializeObject<VendorCommand>(messageText);
                    //_vendorCommandHandler.Handle(vendorCommand);
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
