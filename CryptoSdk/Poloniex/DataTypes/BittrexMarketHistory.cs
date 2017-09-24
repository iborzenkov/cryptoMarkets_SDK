using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class BittrexMarketHistoryDataType : Bittrex.DataTypes.BaseDataType
    {
        /// <summary>
        /// Market Summaries
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexMarketHistoryItemDataType[] Items { get; set; }
    }

    [DataContract]
    public class BittrexMarketHistoryItemDataType
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "Id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [DataMember(Name = "Price", EmitDefaultValue = false)]
        public double Price { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        [DataMember(Name = "Total", EmitDefaultValue = false)]
        public double Total { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        [DataMember(Name = "OrderType", EmitDefaultValue = false)]
        public string OrderType { get; set; }

        /// <summary>
        /// TimeStamp
        /// </summary>
        [DataMember(Name = "TimeStamp", EmitDefaultValue = false)]
        public string TimeStamp { get; set; }
    }
}