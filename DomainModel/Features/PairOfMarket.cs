﻿using System;

namespace DomainModel.Features
{
    public class PairOfMarket //: IEquatable<PairOfMarket>
    {
        public Pair Pair { get; }
        public Market Market { get; }

        public double? MinTradeSize { get; }

        public bool IsActive { get; }

        public DateTime? Created { get; }

        public PairOfMarket(Pair pair, Market market) :
            this(pair, market, null)
        {
        }

        public PairOfMarket(Pair pair, Market market, bool isActive) :
            this(pair, market, null, isActive)
        {
        }

        public PairOfMarket(Pair pair, Market market, double? minTradeSize) :
            this(pair, market, minTradeSize, true)
        {
        }

        public PairOfMarket(Pair pair, Market market, double? minTradeSize, bool isActive) :
            this(pair, market, minTradeSize, isActive, null)
        {
        }

        public PairOfMarket(Pair pair, Market market, double? minTradeSize, bool isActive,
            DateTime? created)
        {
            Pair = pair;
            Market = market;
            MinTradeSize = minTradeSize;
            IsActive = isActive;
            Created = created;

            Buy = new Buy(Pair);
            Sell = new Sell(Pair);
        }

        /*public bool Equals(PairOfMarket other)
        {
            return other != null && Pair.Equals(other.Pair) && Market.Equals(other.Market);
        }*/

        public override string ToString()
        {
            return Pair.ToString();
        }

        public Buy Buy { get; }
        public Sell Sell { get; }
    }
}