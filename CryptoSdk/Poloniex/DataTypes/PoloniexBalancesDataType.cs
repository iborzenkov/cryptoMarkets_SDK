using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexBalanceDataType
    {
        /// <summary>
        /// Available
        /// </summary>
        [DataMember(Name = "Available", EmitDefaultValue = false)]
        public double? Available { get; set; }

        /// <summary>
        /// Pending
        /// </summary>
        [DataMember(Name = "onOrders", EmitDefaultValue = false)]
        public double? Pending { get; set; }

        /// <summary>
        /// Btc equivalent
        /// </summary>
        [DataMember(Name = "btcValue", EmitDefaultValue = false)]
        public string BtcEquivalent { get; set; }
    }
}