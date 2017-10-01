using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexOpenedOrdersDataType 
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
    }
}