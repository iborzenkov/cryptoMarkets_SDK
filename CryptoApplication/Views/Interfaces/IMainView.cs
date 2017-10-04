using System;
using System.Windows.Forms;

namespace Views.Interfaces
{
    public interface IMainView : IView
    {
        Form MdiParentForm { get; }

        event Action ShowOrderBook;

        event Action ShowCurrencies;

        event Action ShowPairs;

        event Action ShowApiKeys;

        event Action ShowBalances;

        event Action ShowTrade;

        event Action ShowBlowoutVolumeStrategy;

        event Action ShowCandlestickGraph;

        event Action Exit;
    }
}