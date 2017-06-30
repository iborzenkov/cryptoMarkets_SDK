namespace Model.Features
{
    public class Tick
    {
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double Last { get; set; }

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