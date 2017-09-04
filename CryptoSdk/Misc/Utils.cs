using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CryptoSdk.Misc
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

        public static bool TryParseToDouble(this string source, out double result, bool allPossibleDividers = true)
        {
            var culture = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);

            if (allPossibleDividers)
            {
                string[] arr = { ",", "." };

                foreach (var divider in arr)
                {
                    culture.NumberFormat.NumberDecimalSeparator = divider;
                    if (double.TryParse(source, NumberStyles.Number, culture, out result))
                        return true;
                }

                result = 0;
                return false;
            }

            if (double.TryParse(source, NumberStyles.Number, culture, out result))
                return true;

            result = 0;
            return false;
        }

    }
}