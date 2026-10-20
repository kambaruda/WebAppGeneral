using Core.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Extensions
{
    public static class JsonableExtensions
    {
        public static string ToJstring(this IJsonable jsonable, JsonSerializerOptions? jsonSerializerOptions = default)
        {
            jsonSerializerOptions ??= new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            return JsonSerializer.Serialize(jsonable, jsonable.GetType(), jsonSerializerOptions);
        }
    }
}
