using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
    [DataContract]
    public class PoloniexCurrenciesDataType : BaseDataType
    {
        /// <summary>
        /// Currencies
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public PoloniexCurrencyDataType Currency { get; set; }
    }

    [DataContract]
    public class PoloniexCurrencyDataType
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string CurrencyName { get; set; }

        /// <summary>
        /// maxDailyWithdrawal
        /// </summary>
        [DataMember(Name = "maxDailyWithdrawal", EmitDefaultValue = false)]
        public double MaxDailyWithdrawal { get; set; }

        /// <summary>
        /// MinConfirmation
        /// </summary>
        [DataMember(Name = "minConf", EmitDefaultValue = false)]
        public int MinConfirmation { get; set; }

        /// <summary>
        /// TxFee
        /// </summary>
        [DataMember(Name = "TxFee", EmitDefaultValue = false)]
        public double TxFee { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        [DataMember(Name = "disabled", EmitDefaultValue = false)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Taxe Fee
        /// </summary>
        [DataMember(Name = "txFee", EmitDefaultValue = false)]
        public double TaxeFee { get; set; }
    }
}