using System;

namespace DomainModel.Features
{
    public class HistoryPrice
    {
        public double High { get; }
        public double Low { get; }
        public double Open { get; }
        public double Close { get; }
        public double Volume { get; }
        public double QuoteVolume { get; }
        public DateTime TimeStamp { get; }

        public HistoryPrice(DateTime timeStamp, double open, double close, double high, double low, double volume, double quoteVolume)
        {
            TimeStamp = timeStamp;
            Open = open;
            Close = close;
            High = high;
            Low = low;
            Volume = volume;
            QuoteVolume = quoteVolume;
        }
    }
}