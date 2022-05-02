using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Test.Integration.IncomeApplications
{
    public class IncomeApplicationControllerTest
    {
        internal readonly HttpClient _client;
        internal HttpContent GetStringJsonContent(string body)
        {
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
    }
}
