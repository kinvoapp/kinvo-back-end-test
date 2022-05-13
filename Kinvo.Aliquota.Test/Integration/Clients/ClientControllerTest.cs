using Kinvo.Aliquota.Models.Clients;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kinvo.Aliquota.Test.Integration.Clients
{
    public class ClientControllerTest
    {
        internal readonly HttpClient _client;
        internal HttpContent GetStringJsonContent(string body)
        {
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
        

        [Fact]
        public async Task PostClient()
        {

            var cliente = new ClientRequest
            {
                Active = true,
                Cpf = "00000000000",
                Name = "Teste"
            };

            var contentString = GetStringJsonContent(JsonConvert.SerializeObject(cliente));

            var httpResponse = await _client.PostAsync("/client", contentString);

            Assert.Equal(System.Net.HttpStatusCode.Created, httpResponse.StatusCode);
        }
    }
}
