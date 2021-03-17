using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleKinvoBackEndTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastrando Cliente!");

            RegisterCustomer();

            Console.WriteLine("Relacinando cliente (Id 1) ao produto (Id 1).");

            RegisterCustomerProduct();

            Console.WriteLine("Realizando uma aplicação no produto 1.");

            RegisterMovementApplication();

            Console.WriteLine("Realizar resgate do produto 1.");

            RegisterMovementRescue();

        }

        private static void RegisterMovementRescue()
        {
            dynamic movementRescue = new { QtLot = 10, ProductId = 1, Value = 100.00, DtRescue = "2020-03-15 01:00:00", DtRegister = "2020-03-15 01:00:00" };

            try
            {
                if (CallExternalAPI(JObject.FromObject(movementRescue).ToString(), "https://localhost:44345/api/MovementRescue"))
                {
                    Console.WriteLine("Associação cliente x produto realizada com sucesso");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else
                {
                    // no http status code available
                }
            }
        }

        private static void RegisterMovementApplication()
        {
            dynamic movementApplication = new { QtLot = 10, ProductId = 1, Value = 100.00, DtRegister = "2020-03-15 01:00:00" };

            try
            {
                if (CallExternalAPI(JObject.FromObject(movementApplication).ToString(), "https://localhost:44345/api/MovementApplication"))
                {
                    Console.WriteLine("Associação cliente x produto realizada com sucesso");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else
                {
                    // no http status code available
                }
            }
        }

        private static void RegisterCustomerProduct()
        {
            dynamic customerProduct = new { CustomerId = 1, ProductId = 1 };

            try
            {
                if (CallExternalAPI(JObject.FromObject(customerProduct).ToString(), "https://localhost:44345/api/CustomerProduct"))
                {
                    Console.WriteLine("Associação cliente x produto realizada com sucesso");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else
                {
                    // no http status code available
                }
            }
        }

        private static void RegisterCustomer()
        {
            dynamic customer = new { NmCustomer = "Antonio Teste", Telephone = "4899305878", Email = "teste@teste.com" };

            try
            {
                if (CallExternalAPI(JObject.FromObject(customer).ToString(), "https://localhost:44345/api/Customer"))
                {
                    Console.WriteLine("Cliente \"" + customer + "\" cadastrado com sucesso");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else
                {
                    // no http status code available
                }
            }
        }

        public static bool CallExternalAPI(string json, string url)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var webResponse =  (HttpWebResponse)httpWebRequest.GetResponse();

            return webResponse.StatusCode == HttpStatusCode.OK;

        }
    }
}
