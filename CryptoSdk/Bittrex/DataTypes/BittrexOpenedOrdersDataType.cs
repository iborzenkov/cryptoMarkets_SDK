﻿using System.Runtime.Serialization;

namespace CryptoSdk.Bittrex.DataTypes
{
    [DataContract]
    public class BittrexOpenedOrdersDataType : BaseDataType
    {
        /// <summary>
        /// Balances
        /// </summary>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public BittrexOpenedLimitOrderItemDataType[] Orders { get; set; }
    }

    [DataContract]
    public class BittrexOpenedLimitOrderItemDataType
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember(Name = "OrderUuid", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Pair
        /// </summary>
        [DataMember(Name = "Exchange", EmitDefaultValue = false)]
        public string Pair { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        [DataMember(Name = "OrderType", EmitDefaultValue = false)]
        public string OrderType { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [DataMember(Name = "Price", EmitDefaultValue = false)]
        public double Price { get; set; }

        /// <summary>
        /// Limit Price
        /// </summary>
        [DataMember(Name = "Limit", EmitDefaultValue = false)]
        public double Limit { get; set; }

        /// <summary>
        /// Opened
        /// </summary>
        [DataMember(Name = "Opened", EmitDefaultValue = false)]
        public string Opened { get; set; }
    }
}