using System;
using System.IO;

using Newtonsoft.Json;

using Formatting = System.Xml.Formatting;

namespace Tools
{
    public static class DataSerializer
    {
        public static void DeserializeJson<T>(string fileName, ref T container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            container = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName), new JsonSerializerSettings
                                                                                     {
                                                                                         TypeNameHandling = TypeNameHandling.Auto,
                                                                                         NullValueHandling = NullValueHandling.Ignore,
                                                                                     });
        }

        public static void SerializeJson<T>(string fileName, ref T container)
        {

            var serializer = new JsonSerializer();
            //serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            using (var sw = new StreamWriter(fileName))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, container, typeof(T));
                }
            }

        }
    }
}
