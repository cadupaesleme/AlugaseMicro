using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorMicro.Domain.VendorAggregate;

namespace VendorConsole
{
    class Program
    {
        const string _ConnectionString = ("DefaultEndpointsProtocol=https;AccountName=alugasestorage;AccountKey=P4il7lcfc8wdXTe1cQULpzcyp3+i+U9BkjxtJWd6e9zRd8R67aFW7RQTfLv1xp8G8M8RzqBLjMLcdNMibRFZHw==;EndpointSuffix=core.windows.net");
        const string _QueueName = "filateste";
        static IQueueClient queueClient;


        //static void Main(string[] args)
        //{
        //    new Program().run();
        //}
        static async Task Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(_QueueName);


            //string value = await ReceiveMessageAsync(queue);
            //Console.WriteLine($"Received: {value}");

            string messageText = "";
            do
            {
                var message = await ReceiveMessageAsync(queue);

                if (message == null)
                    continue;

                    messageText = message.ToString();
                try
                {
                    var vendor = Newtonsoft.Json.JsonConvert.DeserializeObject<Vendor>(messageText);
                    Console.WriteLine($"Received: {vendor.Id} - {vendor.Name}");
                }
                catch (Exception ex) { Console.WriteLine(messageText); };
                System.Threading.Thread.Sleep(1000);
            } while (messageText != "quit");

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
