using System;

namespace DomainModel.Features
{
    public class PairStatistic
    {
        private double? _dailyChange;
        public Pair Pair { get; }
        public double High { get; }
        public double Low { get; }
        public double BaseVolume { get; }
        public double QuoteVolume { get; }
        public double Last { get; }
        public double? PrevDayPrice { get; }
        public int? OpenBuyOrders { get; }
        public int? OpenSellOrders { get; }

        public PairStatistic(Pair pair, double high, double low, double baseVolume, double quoteVolume, double last, double dailyChange)
            : this(pair, high, low, baseVolume, quoteVolume, last, null, null, null, dailyChange)
        {
        }

        public PairStatistic(Pair pair, double high, double low, double baseVolume, double quoteVolume, double last,
            double? prevDayPrice, int? openBuyOrders, int? openSellOrders) 
            : this(pair, high, low, baseVolume, quoteVolume, last, prevDayPrice, openBuyOrders, openSellOrders, null)
        {
            
        }

            public PairStatistic(Pair pair, double high, double low, double baseVolume, double quoteVolume, double last,
            double? prevDayPrice, int? openBuyOrders, int? openSellOrders, double? dailyChange)
        {
            Pair = pair;
            High = high;
            Low = low;
            BaseVolume = baseVolume;
            QuoteVolume = quoteVolume;
            Last = last;
            PrevDayPrice = prevDayPrice;
            OpenBuyOrders = openBuyOrders;
            OpenSellOrders = openSellOrders;
            _dailyChange = dailyChange;
        }

        public double DailyChangeOfLastPrice()
        {
            return DailyChange(Last);
        }

        public double DailyChange(double currentPrice)
        {
            if (_dailyChange.HasValue)
                return _dailyChange.Value * 100;

            if (PrevDayPrice != null)
                return (currentPrice - PrevDayPrice.Value) / PrevDayPrice.Value * 100;

            throw new Exception("DailyChange failt");
        }
    }
}