using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexTickerDataType
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Bid
        /// </summary>
        [DataMember(Name = "highestBid", EmitDefaultValue = false)]
        public double Bid { get; set; }

        /// <summary>
        /// Ask
        /// </summary>
        [DataMember(Name = "lowestAsk", EmitDefaultValue = false)]
        public double Ask { get; set; }

        /// <summary>
        /// Last
        /// </summary>
        [DataMember(Name = "last", EmitDefaultValue = false)]
        public double Last { get; set; }

        /// <summary>
        /// Daily Change
        /// </summary>
        [DataMember(Name = "percentChange", EmitDefaultValue = false)]
        public double DailyChange { get; set; }

        /// <summary>
        /// Base Volume
        /// </summary>
        [DataMember(Name = "baseVolume", EmitDefaultValue = false)]
        public double BaseVolume { get; set; }

        /// <summary>
        /// Quote Volume
        /// </summary>
        [DataMember(Name = "quoteVolume", EmitDefaultValue = false)]
        public double QuoteVolume { get; set; }

        /// <summary>
        /// Is Frozen
        /// </summary>
        [DataMember(Name = "isFrozen", EmitDefaultValue = false)]
        public bool IsFrozen { get; set; }

        /// <summary>
        /// High 24hr
        /// </summary>
        [DataMember(Name = "high24hr", EmitDefaultValue = false)]
        public double High24Hr { get; set; }

        /// <summary>
        /// Low 24hr
        /// </summary>
        [DataMember(Name = "low24hr", EmitDefaultValue = false)]
        public double Low24Hr { get; set; }
    }
}