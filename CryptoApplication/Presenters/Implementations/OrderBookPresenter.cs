using DomainModel.Features;
using DomainModel.MarketModel;
using Models;
using Models.Interfaces;
using System;
using System.Linq;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class OrderBookPresenter : BasePresenter<IOrderBookView>
    {
        private IOrderBookModel Model { get; }

        public OrderBookPresenter(IOrderBookView view, IOrderBookModel model) : base(view)
        {
            Model = model;
            Model.OrderBookChanged += Model_OrderBookChanged;

            View.SetMarkets(Model.Markets);
            View.SetOrderBookSettings(Model.OrderBookSettings);

            View.MarketChanged += View_MarketChanged;
            View.PairChanged += View_PairChanged;
            View.OrderBookSettingsChanged += View_OrderBookSettingsChanged;
            View.ViewClosed += View_ViewClosed;

            if (Model.Markets.Any())
                View.Market = Model.Markets.First();
        }

        private void View_OrderBookSettingsChanged(object sender, OrderBookSettings settings)
        {
            Model.OrderBookSettings = settings;
        }

        private void View_ViewClosed(object sender, EventArgs eventArgs)
        {
            Release();
        }

        private void Release()
        {
            Model.OrderBookChanged -= Model_OrderBookChanged;
            Model.Release();
        }

        private void Model_OrderBookChanged(object sender, IOrderBook orderBook)
        {
            View.SetOrderBook(orderBook);
        }

        private void View_PairChanged(object sender, PairOfMarket pair)
        {
            Model.NeedOrderBookOf(View.Pair);
        }

        private void View_MarketChanged(object sender, Market market)
        {
            var selectedPair = View.Pair;

            var pairs = market.Pairs;
            var pairOfMarkets = pairs as PairOfMarket[] ?? pairs.ToArray();
            View.SetPairs(pairOfMarkets);

            if (selectedPair != null)
                View.Pair = pairOfMarkets.FirstOrDefault(pairOfMarket => pairOfMarket.Pair.Equals(selectedPair.Pair));
        }
    }
}