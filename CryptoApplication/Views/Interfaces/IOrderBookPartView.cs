using DomainModel.MarketModel;

namespace Views.Interfaces
{
    public interface IOrderBookPartView
    {
        void SetOrderBook(IOrderBook orderBook);

        void SetUsdRate(double? usdRate);

        void ClearOrderBookParts();

        void Close();
    }
}