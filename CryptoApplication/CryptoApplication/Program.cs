using CryptoSdk.Bittrex.Model;
using CryptoSdk.Dummy;
using CryptoSdk.Poloniex.Model;
using DomainModel;
using DomainModel.Features;
using Presenters.Implementations;
using System;
using System.Windows.Forms;
using Views.Implementations;
using Model = Models.Implementations.Model;

namespace CryptoApplication
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var domainModel = new DomainModel.Model();
            var bittrexModel = new BittrexModel();
            var poloniexModel = new PoloniexModel();
            //var bittrexModel = new DummyModel();
            //var poloniexModel = new PoloniexModel();

            var bittrexMarket = new Market("Bittrex", bittrexModel,
                new[] { ApiKeyRole.Info, ApiKeyRole.TradeLimit, ApiKeyRole.TradeMarket, ApiKeyRole.Withdraw },
                "USDT",
                new TimeframeType[0]);
            domainModel.AddMarket(bittrexMarket);

            var poloniexMarket = new Market("Poloniex", poloniexModel,
                new[] { ApiKeyRole.Trade, },
                "USDT",
                new[] { TimeframeType.M5, TimeframeType.M15, TimeframeType.M30, TimeframeType.H2, TimeframeType.H4, TimeframeType.D1, });
            domainModel.AddMarket(poloniexMarket);

            var main = new MainPresenter(new MainForm(), new Model(domainModel));

            main.Run();
        }
    }
}