using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KinvoTesteConsole.Helper
{
    public class HttpClientHelper
    {
        private const string UrlService = "http://localhost:5000/";
        public static string token;

        protected readonly HttpClient _httpClient;

        public HttpClientHelper()
        {
            _httpClient = new HttpClient();
            if(!string.IsNullOrWhiteSpace(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private string AddParameter(Dictionary<string, object> parameters)
        {
            var parametros = string.Empty;

            if (parameters != null)
                foreach (var item in parameters)
                {
                    parametros += string.Format("/{0}", item.Value);
                }

            return parametros;
        }

        public async Task<string> Get(string nomeMetodo, Dictionary<string, object> parameters = null)
        {
            var parametros = AddParameter(parameters);

            var RestUrl = string.Format("{0}{1}{2}", UrlService, nomeMetodo, parametros);
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            var response = await _httpClient.GetAsync(uri);
            var retorno = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception(retorno);

            return retorno;
        }

        public async Task<string> Post(string nomeMetodo, Dictionary<string, object> parameters = null)
        {
            var parametros = string.Empty;

            if (parameters.Count > 0)
                foreach (var item in parameters)
                {
                    parametros += item.Value.ToString();
                }

            var RestUrl = string.Format("{0}{1}", UrlService, nomeMetodo);

            var stringContent = new StringContent(parametros, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(RestUrl, stringContent);
            var retorno = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception(retorno);

            return retorno;
        }

        public async Task<string> Path(string nomeMetodo, Dictionary<string, object> parameters = null)
        {
            var parametros = string.Empty;

            if (parameters.Count > 0)
                foreach (var item in parameters)
                {
                    parametros += item.Value.ToString();
                }

            var RestUrl = string.Format("{0}{1}", UrlService, nomeMetodo);

            var stringContent = new StringContent(parametros, Encoding.UTF8, "application/json");

            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, RestUrl)
            {
                Content = stringContent
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            var retorno = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception(retorno);

            return retorno;
        }
    }
}
