using System;

namespace DomainModel.Features
{
    public class Pair24HoursStatistic
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
        public DateTime? TimeStamp { get; }

        public Pair24HoursStatistic(Pair pair, double high, double low, double baseVolume, double quoteVolume, double last, double dailyChange)
            : this(pair, high, low, baseVolume, quoteVolume, last, null, null, null, dailyChange, DateTime.Now)
        {
        }

        public Pair24HoursStatistic(Pair pair, double high, double low, double baseVolume, double quoteVolume, double last,
            double? prevDayPrice, int? openBuyOrders, int? openSellOrders, DateTime? timeStamp)
            : this(pair, high, low, baseVolume, quoteVolume, last, prevDayPrice, openBuyOrders, openSellOrders, null, timeStamp)
        {
        }

        public Pair24HoursStatistic(Pair pair, double high, double low, double baseVolume, double quoteVolume, double last,
            double? prevDayPrice, int? openBuyOrders, int? openSellOrders, double? dailyChange, DateTime? timeStamp)
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
            TimeStamp = timeStamp;
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