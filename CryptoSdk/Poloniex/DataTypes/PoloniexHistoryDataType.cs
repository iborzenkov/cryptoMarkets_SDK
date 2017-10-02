using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexHistoryDataType
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public ulong TimeStamp { get; set; }

        /// <summary>
        /// High
        /// </summary>
        [DataMember(Name = "high", EmitDefaultValue = false)]
        public double High { get; set; }

        /// <summary>
        /// Low
        /// </summary>
        [DataMember(Name = "low", EmitDefaultValue = false)]
        public double Low { get; set; }

        /// <summary>
        /// Open
        /// </summary>
        [DataMember(Name = "open", EmitDefaultValue = false)]
        public double Open { get; set; }

        /// <summary>
        /// Close
        /// </summary>
        [DataMember(Name = "close", EmitDefaultValue = false)]
        public double Close { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public double Volume { get; set; }

        /// <summary>
        /// Quote Volume
        /// </summary>
        [DataMember(Name = "quoteVolume", EmitDefaultValue = false)]
        public double QuoteVolume { get; set; }
    }
}