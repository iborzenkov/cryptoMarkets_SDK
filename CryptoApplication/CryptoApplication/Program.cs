using CryptoSdk.Dummy;
using DomainModel.Features;
using Models.Implementations;
using Presenters.Implementations;
using System;
using System.Windows.Forms;
using CryptoSdk.Bittrex.Model;
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
            var marketModel = new BittrexModel();
            //var marketModel = new DummyModel();

            var market = new Market("Bittrex", marketModel, new[] { ApiKeyRole.Info, ApiKeyRole.Trade, ApiKeyRole.Account });

            domainModel.AddMarket(market);

            var main = new MainPresenter(new MainForm(), new Model(domainModel));

            main.Run();
        }
    }
}