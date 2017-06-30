using System;
using System.Runtime.Serialization;
using Model;
using Model.Features;

namespace BittrexModel.DataTypes
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
        public DateTime TimeStamp { get; set; }

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
        public int OpenBuyOrders { get; set; }

        /// <summary>
        /// OpenSellOrders
        /// </summary>
        [DataMember(Name = "OpenSellOrders", EmitDefaultValue = false)]
        public int OpenSellOrders { get; set; }

        public MarketSummary ToMarketSummary
        {
            get
            {
                Currency baseCurrency;
                Currency quoteCurrency;
                Pair pair;
                if (Currency.TryParse(BaseCurrency, out baseCurrency) &&
                    Currency.TryParse(QuoteCurrency, out quoteCurrency))
                {
                    var market = new Market(
                        new Pair(baseCurrency, quoteCurrency), 
                        MinTradeSize,
                        IsActive);

                    DateTime dateTime;
                    if (DateTime.TryParse(Created, out dateTime))
                        market.Created = dateTime;

                    return market;
                }
                return null;
            }
        }
    }
}