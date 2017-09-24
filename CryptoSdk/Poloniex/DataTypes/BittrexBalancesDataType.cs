using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class BittrexBalancesDataType : Bittrex.DataTypes.BaseDataType
    {
        /// <summary>
        /// Balances
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexBalanceItemDataType[] Balances { get; set; }
    }

    [DataContract]
    public class BittrexBalanceDataType : Bittrex.DataTypes.BaseDataType
    {
        /// <summary>
        /// Balance
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexBalanceItemDataType Balance { get; set; }
    }

    [DataContract]
    public class BittrexBalanceItemDataType
    {
        /// <summary>
        /// Currency
        /// </summary>
        [DataMember(Name = "Currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// Balance
        /// </summary>
        [DataMember(Name = "Balance", EmitDefaultValue = false)]
        public double? Balance { get; set; }

        /// <summary>
        /// Available
        /// </summary>
        [DataMember(Name = "Available", EmitDefaultValue = false)]
        public double? Available { get; set; }

        /// <summary>
        /// Pending
        /// </summary>
        [DataMember(Name = "Pending", EmitDefaultValue = false)]
        public double? Pending { get; set; }

        /// <summary>
        /// CryptoAddress
        /// </summary>
        [DataMember(Name = "CryptoAddress", EmitDefaultValue = false)]
        public string CryptoAddress { get; set; }
    }
}