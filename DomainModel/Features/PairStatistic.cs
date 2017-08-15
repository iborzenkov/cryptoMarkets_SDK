namespace DomainModel.Features
{
    public class PairStatistic
    {
        public Pair Pair { get; }
        public double High { get; }
        public double Low { get; }
        public double Volume { get; }
        public double Last { get; }
        public double PrevDayPrice { get; }
        public int OpenBuyOrders { get; }
        public int OpenSellOrders { get; }

        public PairStatistic(Pair pair, double high, double low, double volume, 
            double last, double prevDayPrice, int openBuyOrders, int openSellOrders)
        {
            Pair = pair;
            High = high;
            Low = low;
            Volume = volume;
            Last = last;
            PrevDayPrice = prevDayPrice;
            OpenBuyOrders = openBuyOrders;
            OpenSellOrders = openSellOrders;
        }

        public double DailyChangeOfLastPrice()
        {
            return DailyChange(Last);
        }

        public double DailyChange(double currentPrice)
        {
            //return PrevDayPrice / (currentPrice - PrevDayPrice) * 100;
            return (currentPrice - PrevDayPrice) / PrevDayPrice * 100;
        }
    }
}