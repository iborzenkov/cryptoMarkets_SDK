﻿using System;
using Model.Features;

namespace BittrexModel
{
    public class MarketSummary
    {
        public Pair Pair { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
        public double Last { get; set; }
        public double BaseVolume { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Bid { get; set; }
        public int CountOpenedBuyOrders { get; set; }
        public int CountOpenedSellOrders { get; set; }
    }
}