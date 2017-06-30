using Model;
using System.Runtime.Serialization;
using Model.Features;

namespace BittrexModel.DataTypes
{
    [DataContract]
    public class BittrexTickerDataType : BaseDataType
    {
        /// <summary>
        /// Ticker
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public TickerDataType Ticker { get; set; }
    }

    [DataContract]
    public class TickerDataType : BaseDataType
    {
        /// <summary>
        /// Bid
        /// </summary>
        [DataMember(Name = "Bid", EmitDefaultValue = false)]
        public double Bid { get; set; }

        /// <summary>
        /// Bid
        /// </summary>
        [DataMember(Name = "Ask", EmitDefaultValue = false)]
        public double Ask { get; set; }

        /// <summary>
        /// Last
        /// </summary>
        [DataMember(Name = "Last", EmitDefaultValue = false)]
        public double Last { get; set; }

        public Tick ToTick => new Tick(Bid, Ask, Last);
    }
}