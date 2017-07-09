using System.Runtime.Serialization;

namespace CryptoSdk.Bittrex.DataTypes
{
    [DataContract]
    public class BittrexMarketSummaries : BaseDataType
    {
        /// <summary>
        /// Market Summaries
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexMarketSummary[] MarketSummaries { get; set; }
    }

    [DataContract]
    public class BittrexMarketSummary
    {
        /// <summary>
        /// MarketName
        /// </summary>
        [DataMember(Name = "MarketName", EmitDefaultValue = false)]
        public string MarketName { get; set; }

        /// <summary>
        /// High
        /// </summary>
        [DataMember(Name = "High", EmitDefaultValue = false)]
        public double High { get; set; }

        /// <summary>
        /// Low
        /// </summary>
        [DataMember(Name = "Low", EmitDefaultValue = false)]
        public double Low { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        [DataMember(Name = "Volume", EmitDefaultValue = false)]
        public double Volume { get; set; }

        /// <summary>
        /// Last
        /// </summary>
        [DataMember(Name = "Last", EmitDefaultValue = false)]
        public double Last { get; set; }

        /// <summary>
        /// BaseVolume
        /// </summary>
        [DataMember(Name = "BaseVolume", EmitDefaultValue = false)]
        public double BaseVolume { get; set; }

        /// <summary>
        /// TimeStamp
        /// </summary>
        [DataMember(Name = "TimeStamp", EmitDefaultValue = false)]
        public string TimeStamp { get; set; }

        /// <summary>
        /// Bid
        /// </summary>
        [DataMember(Name = "Bid", EmitDefaultValue = false)]
        public double Bid { get; set; }

        /// <summary>
        /// Ask
        /// </summary>
        [DataMember(Name = "Ask", EmitDefaultValue = false)]
        public double Ask { get; set; }

        /// <summary>
        /// OpenBuyOrders
        /// </summary>
        [DataMember(Name = "OpenBuyOrders", EmitDefaultValue = false)]
        public int CountOpenBuyOrders { get; set; }

        /// <summary>
        /// OpenSellOrders
        /// </summary>
        [DataMember(Name = "OpenSellOrders", EmitDefaultValue = false)]
        public int CountOpenSellOrders { get; set; }
    }
}