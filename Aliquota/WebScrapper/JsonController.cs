using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WebScrapper
{
    public static class JsonController
    {
        public static dynamic ReadFile<T>(string filePath)
        {
            var stream = System.IO.File.ReadAllText(filePath);
            return Readstring<T>(stream);
        }
        public static dynamic Readstring<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}