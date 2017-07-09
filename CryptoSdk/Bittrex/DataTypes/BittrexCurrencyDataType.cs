using System.Runtime.Serialization;

namespace CryptoSdk.Bittrex.DataTypes
{
    [DataContract]
    public class BittrexCurrenciesDataType : BaseDataType
    {
        /// <summary>
        /// Currencies
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexCurrencyDataType[] Currencies { get; set; }
    }

    [DataContract]
    public class BittrexCurrencyDataType
    {
        /// <summary>
        /// Currency
        /// </summary>
        [DataMember(Name = "Currency", EmitDefaultValue = false)]
        public string CurrencyName { get; set; }

        /// <summary>
        /// CurrencyLongName
        /// </summary>
        [DataMember(Name = "CurrencyLong", EmitDefaultValue = false)]
        public string CurrencyLongName { get; set; }

        /// <summary>
        /// MinConfirmation
        /// </summary>
        [DataMember(Name = "MinConfirmation", EmitDefaultValue = false)]
        public int MinConfirmation { get; set; }

        /// <summary>
        /// TxFee
        /// </summary>
        [DataMember(Name = "TxFee", EmitDefaultValue = false)]
        public double TxFee { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        [DataMember(Name = "IsActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }

        /// <summary>
        /// BaseAddress
        /// </summary>
        [DataMember(Name = "BaseAddress", EmitDefaultValue = false)]
        public string BaseAddress { get; set; }
    }
}