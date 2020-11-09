using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Aliquota.Front
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("**************************** RESGATE DE INVESTIMENTO ****************************");

            Console.Write("Digite o seu CPF: ");
            string cpf = Console.ReadLine();
            RetornarImposto(cpf).GetAwaiter().GetResult();           
        }

        private static async Task RetornarImposto(string cpf)
        
        {
            try
            {
                var url = "http://localhost:64439/api/clientes/" + cpf;
                httpClient.BaseAddress = new Uri(url);
                
                                httpClient.DefaultRequestHeaders.Accept.Clear();
                                httpClient.DefaultRequestHeaders.Accept.Add(
                                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync(url);
                var imposto = await response.Content.ReadAsStringAsync();
                
                Console.Write("O valor de imposto do seu resgate é de: " + imposto);

                Console.ReadLine();
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
