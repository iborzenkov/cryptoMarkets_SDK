using DomainModel.Features;

namespace DomainModel.MarketModel
{
    public interface IMarketTrade
    {
        OrderId BuyLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage);

        OrderId SellLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage);

        bool Cancel(Market market, OrderId orderId, out string errorMessage);
    }
}