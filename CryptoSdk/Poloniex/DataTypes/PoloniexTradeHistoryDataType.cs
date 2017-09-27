using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexTradeHistoryDataType
    {
        /// <summary>
        /// GlobalTradeID
        /// </summary>
        [DataMember(Name = "globalTradeID", EmitDefaultValue = false)]
        public int GlobalTradeId { get; set; }

        /// <summary>
        /// TradeID
        /// </summary>
        [DataMember(Name = "tradeID", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [DataMember(Name = "rate", EmitDefaultValue = false)]
        public double Price { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public double Total { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string OrderType { get; set; }

        /// <summary>
        /// Time stamp
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public string TimeStamp { get; set; }
    }
}