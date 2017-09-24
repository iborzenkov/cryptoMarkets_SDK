using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class BittrexOrderBookDataType : Bittrex.DataTypes.BaseDataType
    {
        /// <summary>
        /// OrderBook
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public OrderBookDataType OrderBook { get; set; }
    }

    [DataContract]
    public class BittrexOrderBookOneSideDataType : Bittrex.DataTypes.BaseDataType
    {
        /// <summary>
        /// OrderBook
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public OrderBookPartDataType[] Prices { get; set; }
    }

    [DataContract]
    public class OrderBookDataType
    {
        /// <summary>
        /// Asks
        /// </summary>
        [DataMember(Name = "sell", EmitDefaultValue = false)]
        public OrderBookPartDataType[] Asks { get; set; }

        /// <summary>
        /// Bids
        /// </summary>
        [DataMember(Name = "buy", EmitDefaultValue = false)]
        public OrderBookPartDataType[] Bids { get; set; }
    }

    [DataContract]
    public class OrderBookPartDataType
    {
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        [DataMember(Name = "Rate", EmitDefaultValue = false)]
        public double Price { get; set; }
    }
}