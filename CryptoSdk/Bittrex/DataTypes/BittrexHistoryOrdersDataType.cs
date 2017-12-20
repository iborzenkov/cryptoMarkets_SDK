using System.Runtime.Serialization;

namespace CryptoSdk.Bittrex.DataTypes
{
    [DataContract]
    public class BittrexHistoryOrdersDataType : BaseDataType
    {
        /// <summary>
        /// OrderHistories
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexHistoryOrderItemDataType[] HistoryOrders { get; set; }
    }

    [DataContract]
    public class BittrexHistoryOrderItemDataType
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "OrderUuid", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Pair
        /// </summary>
        [DataMember(Name = "Exchange", EmitDefaultValue = false)]
        public string Pair { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Commission
        /// </summary>
        [DataMember(Name = "Commission", EmitDefaultValue = false)]
        public double Commission { get; set; }

        /// <summary>
        /// Limit
        /// </summary>
        [DataMember(Name = "Limit", EmitDefaultValue = false)]
        public double Limit { get; set; }

        /// <summary>
        /// TimeStamp
        /// </summary>
        [DataMember(Name = "TimeStamp", EmitDefaultValue = false)]
        public string TimeStamp { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        [DataMember(Name = "OrderType", EmitDefaultValue = false)]
        public string OrderType { get; set; }
    }
}