using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexHistoryOrdersDataType 
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "orderNumber", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string OrderType { get; set; }

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
        /// Fee
        /// </summary>
        [DataMember(Name = "fee", EmitDefaultValue = false)]
        public double Fee { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public string Date { get; set; }
    }
}