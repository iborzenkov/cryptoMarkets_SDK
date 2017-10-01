using System.Runtime.Serialization;

namespace CryptoSdk.Bittrex.DataTypes
{
    [DataContract]
    public class BittrexLimitOrderDataType : BaseDataType
    {
        /// <summary>
        /// Balances
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexLimitOrderItemDataType Order { get; set; }
    }

    [DataContract]
    public class BittrexLimitOrderItemDataType
    {
        /// <summary>
        /// uuid
        /// </summary>
        [DataMember(Name = "uuid", EmitDefaultValue = false)]
        public string Id { get; set; }
    }
}