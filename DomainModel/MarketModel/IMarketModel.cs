namespace DomainModel.MarketModel
{
    public interface IMarketModel
    {
        IMarketInfo Info { get; }
        IMarketTrade Trade { get; }
        IAccountInfo Account { get; }

        string AdoptMessage(string message);
    }
}