using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aliquota.Api.Models.Response.Convert
{
    class JsonDateConverter : JsonConverter<DateTime>
        {
       
           public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                    => DateTime.ParseExact(reader.GetString(),
                    "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
                    => writer.WriteStringValue(value.ToString(
                    "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            
        } 
}