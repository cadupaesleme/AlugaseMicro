using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RentMicro.Domain.RentAggregate;
using System.Collections.Generic;

namespace RentConsole
{
    class Program
    {

        private static string url = "http://localhost:57416/";

        static void Main(string[] args)
        {
            Iniciar();

        }

        private static void Iniciar()
        {
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Console Rent   \r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("(1) - Post; (2) - Put; (3) - Delete; (Exit) - Close Console");
            var opcao = (Console.ReadLine());

            switch (opcao)
            {
                case "1":
                    MakePost();
                    Iniciar();
                    break;
                case "2":
                    Console.WriteLine("ID RentItem: ");
                    var idput = (Console.ReadLine());
                    MakePut(idput);
                    Iniciar();
                    break;
                case "3":
                    Console.WriteLine("ID RentItem: ");
                    var iddel = (Console.ReadLine());
                    MakeDelete(iddel);
                    Iniciar();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Errrrrrou!\r");
                    Iniciar();
                    break;
            }
        }

        private async static void ApiCall(string type, string data, string id)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var contentString = new StringContent(data, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            switch (type)
            {
                case "POST":
                    HttpResponseMessage response_post = await client.PostAsync("api/Rent/", contentString);
                    break;
                case "PUT":
                    HttpResponseMessage response_put = await client.PutAsync("api/Rent/" + id, contentString);
                    break;
                case "DELETE":
                    HttpResponseMessage response_delete = await client.DeleteAsync("api/Rent/" + id);
                    break;
            }
        }

        private static void MakeDelete(string id)
        {

            //RentItem item = new RentItem();
            //item.Id = Guid.Parse(id);
            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            ApiCall("DELETE", "", id);
            Console.WriteLine("Envio Realizado!");
        }

        private static void MakePut(string id)
        {
            Random random = new Random();
            //Rent r = new Rent();
            //r.Date = DateTime.Now.ToString();
            //r.Id = Guid.Parse(id);
            //r.RentItens = new List<RentItem>();

            RentItem item = new RentItem();
            item.Id = Guid.Parse(id);
            item.VendorID = Guid.NewGuid();
            item.EndDate = DateTime.Now.AddDays(20).ToShortDateString();
            item.InitialDate = DateTime.Now.ToShortDateString();
            item.Quantity = random.Next(1, 10);
            item.UnitPrice = random.Next(1000, 9000);
            //r.RentItens.Add(item);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            ApiCall("PUT", json, id);
            Console.WriteLine("Envio Realizado!");
        }

        private static void MakePost()
        {
            Random random = new Random();
            Rent r = new Rent();
            r.Date = DateTime.Now.ToString();
            r.CustomerId = Guid.NewGuid();

            RentItem item = new RentItem();
            item.VendorID = Guid.NewGuid();
            item.EndDate = DateTime.Now.AddDays(10).ToShortDateString();
            item.InitialDate = DateTime.Now.ToShortDateString();
            item.Quantity = random.Next(1, 10);
            item.UnitPrice = random.Next(1000, 9000);
            r.RentItens = new List<RentItem>();
            r.RentItens.Add(item);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(r);
            ApiCall("POST", json, "");
            Console.WriteLine("Envio Realizado!");
        }

    }

}
