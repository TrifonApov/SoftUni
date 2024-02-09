using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

<<<<<<< HEAD
namespace Trucks.Extensions
=======
namespace Boardgames.Extensions
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
{
    public static class JsonSerializationExtension
    {
        public static string SerializeToJson<T>(this T obj)
        {
            var jsonSerializer = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,                
                Converters = new List<JsonConverter>()
                {
                    new StringEnumConverter()
                }
            };

            string result = JsonConvert.SerializeObject(obj, jsonSerializer);

            return result;
        }

        public static T DeserializeFromJson<T>(this string jsonString)
        {
            var jsonSerializer = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            T result = JsonConvert.DeserializeObject<T>(jsonString, jsonSerializer);

            return result;
        }
    }
}
