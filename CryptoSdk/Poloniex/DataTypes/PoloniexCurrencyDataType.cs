using System.Runtime.Serialization;

namespace CryptoSdk.Poloniex.DataTypes
{
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
        /// IsActive
        /// </summary>
        [DataMember(Name = "disabled", EmitDefaultValue = false)]
        public bool IsDisabled { get; set; }

        /// <summary>
        /// Tax Fee
        /// </summary>
        [DataMember(Name = "txFee", EmitDefaultValue = false)]
        public double TaxFee { get; set; }

        /// <summary>
        /// Deposit Address
        /// </summary>
        [DataMember(Name = "depositAddress", EmitDefaultValue = false)]
        public string DepositAddress { get; set; }
    }
}