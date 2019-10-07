using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorMicro.Domain.VendorAggregate;

namespace VendorConsole
{
    class Program
    {

        private static string url = "http://localhost:57419/";

        static void Main(string[] args)
        {
            Iniciar();

        }

        private static void Iniciar()
        {
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Console Vendor   \r");
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
                    Console.WriteLine("ID: ");
                    var idput = (Console.ReadLine());
                    MakePut(idput);
                    Iniciar();
                    break;
                case "3":
                    Console.WriteLine("ID: ");
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
                    HttpResponseMessage response_post = await client.PostAsync("api/Vendor/", contentString);
                    break;
                case "PUT":
                    HttpResponseMessage response_put = await client.PutAsync("api/Vendor/" + id, contentString);
                    break;
                case "DELETE":
                    HttpResponseMessage response_delete = await client.DeleteAsync("api/Vendor/" + id);
                    break;
            }
        }

        private static void MakeDelete(string id)
        {


            ApiCall("DELETE", "", id);
            Console.WriteLine("Envio Realizado!");
        }

        private static void MakePut(string id)
        {
            Random random = new Random();
            string[] gen = { "Masc", "Fem" };
            Vendor v = new Vendor();
            v.Id = Guid.Parse(id);
            v.Address = "Rua " + random.Next(1, 100);
            v.Bithday = random.Next(1, 29) + "/" + random.Next(1, 12) + "/" + random.Next(1960, 2000);
            v.Gender = gen[random.Next(1, 2)];
            v.Identification = random.Next(111111111, 999999999).ToString();
            v.Name = "Fulano Vendor Alterador - " + random.Next(1, 999999);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(v);
            ApiCall("PUT", json, id);
            Console.WriteLine("Envio Realizado!");


        }

        private static void MakePost()
        {
            Random random = new Random();
            string[] gen = { "Masc", "Fem" };
            Vendor v = new Vendor();
            v.Address = "Rua " + random.Next(1, 100);
            v.Bithday = random.Next(1, 29) + "/" + random.Next(1, 12) + "/" + random.Next(1960, 2000);
            v.Gender = gen[random.Next(1, 2)];
            v.Identification = random.Next(111111111, 999999999).ToString();
            v.Name = "Fulano Vendor " + random.Next(1, 999999);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(v);
            ApiCall("POST", json, "");
            Console.WriteLine("Envio Realizado!");
        }
    }

}
