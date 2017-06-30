﻿using System.Runtime.Serialization;

namespace Bittrex.DataTypes
{
    [DataContract]
    public class BittrexOrderBookDataType : BaseDataType
    {
        /// <summary>
        /// OrderBook
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public OrderBookDataType OrderBook { get; set; }
    }

    [DataContract]
    public class OrderBookDataType
    {
        /// <summary>
        /// Asks
        /// </summary>
        [DataMember(Name = "buy", EmitDefaultValue = false)]
        public OrderBookPartDataType[] Asks { get; set; }

        /// <summary>
        /// Bids
        /// </summary>
        [DataMember(Name = "sell", EmitDefaultValue = false)]
        public OrderBookPartDataType[] Bids { get; set; }
    }

    [DataContract]
    public class OrderBookPartDataType
    {
        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        [DataMember(Name = "Rate", EmitDefaultValue = false)]
        public double Price { get; set; }
    }
}