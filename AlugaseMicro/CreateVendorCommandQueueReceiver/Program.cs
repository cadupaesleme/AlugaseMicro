using System;
using System.Threading.Tasks;
using VendorMicro.Domain.QueueManager;

namespace CreateVendorCommandQueueReceiver
{
    class Program
    {
        const string _queueName = "create-vendor-command-queue";
        static void Main(string[] args)
        {

            //Task awakeReceive = Task.Run(() => QueueSender.Receive(_queueName));
        }
    }
}
