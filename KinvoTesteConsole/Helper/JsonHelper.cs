using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KinvoTesteConsole.Helper
{
    public static class JsonHelper
    {
        public static T To<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

        public static string ToJson(this object value)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            });
        }
    }
}
