namespace Model.Features
{
    public class Tick
    {
        /// <summary>
        /// Bid price
        /// </summary>
        public double Bid { get; }

        /// <summary>
        /// Ask price
        /// </summary>
        public double Ask { get; }

        /// <summary>
        /// Last price
        /// </summary>
        public double Last { get; }

        public Tick(double bid, double ask)
        {
            Bid = bid;
            Ask = ask;
        }

        public Tick(double bid, double ask, double last) : this(bid, ask)
        {
            Last = last;
        }
    }
}