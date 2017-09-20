namespace DomainModel.Features
{
    public class Trade
    {
        private PairOfMarket _pair;

        public Trade(PairOfMarket pair)
        {
            _pair = pair;
        }
    }
}