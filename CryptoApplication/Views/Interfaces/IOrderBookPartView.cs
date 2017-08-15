using DomainModel.MarketModel;

namespace Views.Interfaces
{
    public interface IOrderBookPartView
    {
        void SetOrderBook(IOrderBook orderBook);

        void Close();
    }
}