using System.Runtime.Serialization;

namespace Bittrex.DataTypes
{
    [DataContract]
    public class BittrexMarketsDataType : BaseDataType
    {
        /// <summary>
        /// Markets
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexMarketDataType[] Markets { get; set; }
    }

    [DataContract]
    public class BittrexMarketDataType
    {
        /// <summary>
        /// QuoteCurrency
        /// </summary>
        [DataMember(Name = "MarketCurrency", EmitDefaultValue = false)]
        public string QuoteCurrency { get; set; }

        /// <summary>
        /// BaseCurrency
        /// </summary>
        [DataMember(Name = "BaseCurrency", EmitDefaultValue = false)]
        public string BaseCurrency { get; set; }

        /// <summary>
        /// MinTradeSize
        /// </summary>
        [DataMember(Name = "MinTradeSize", EmitDefaultValue = false)]
        public double MinTradeSize { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        [DataMember(Name = "IsActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        [DataMember(Name = "Created", EmitDefaultValue = false)]
        public string Created { get; set; }
    }
}