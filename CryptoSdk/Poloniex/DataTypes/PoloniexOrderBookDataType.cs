using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexOrderBookDataType
    {
        /// <summary>
        /// Asks
        /// </summary>
        [DataMember(Name = "asks", EmitDefaultValue = false)]
        //public List<string[]> Asks { get; set; }
        public List<string[]> Asks { get; set; }

        /// <summary>
        /// Bids
        /// </summary>
        [DataMember(Name = "bids", EmitDefaultValue = false)]
        public List<string[]> Bids { get; set; }
    }
}