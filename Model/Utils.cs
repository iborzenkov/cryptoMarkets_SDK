using System.IO;
using System.Runtime.Serialization.Json;

namespace Model
{
    public static class Utils
    {
        /// <summary>
        /// Reads JSON object for a stream
        /// Any DataContractJsonSerializer can be thrown
        /// </summary>
        public static T ReadObject<T>(this Stream stream)
        {
            var settings = new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            };
            var parser = new DataContractJsonSerializer(typeof(T), settings);

            return (T)parser.ReadObject(stream);
        }
    }
}