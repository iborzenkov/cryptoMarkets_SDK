using System.Runtime.Serialization;
using Model;
using Model.Features;

namespace BittrexModel.DataTypes
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

        public Currency ToCurrency
        {
            get
            {
                Currency currency;
                if (Currency.TryParse(CurrencyName, out currency))
                    return currency;

                return null;
            }
        }
    }
}