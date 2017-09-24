using CryptoSdk.Bittrex.Model;
using CryptoSdk.Dummy;
using DomainModel.Features;
using Models.Implementations;
using Presenters.Implementations;
using System;
using System.Windows.Forms;
using CryptoSdk.Poloniex.Model;
using Views.Implementations;

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

            var bittrexMarket = new Market("Bittrex", bittrexModel, new[]
            {
                ApiKeyRole.Info, ApiKeyRole.TradeLimit, ApiKeyRole.TradeMarket, ApiKeyRole.Withdraw
            },
            "USDT");
            domainModel.AddMarket(bittrexMarket);

            var poloniexMarket = new Market("Poloniex", poloniexModel, new[]
            {
                ApiKeyRole.Trade,
            },
            "USDT");
            domainModel.AddMarket(poloniexMarket);

            var main = new MainPresenter(new MainForm(), new Model(domainModel));

            main.Run();
        }
    }
}