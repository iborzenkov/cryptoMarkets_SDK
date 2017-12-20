using System;
using Models.Implementations;
using Models.Interfaces;
using Views.Implementations;
using Views.Interfaces;

namespace Presenters.Implementations
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IModel _model;

        public MainPresenter(IMainView view, IModel model) : base(view)
        {
            View.ShowOrderBook += View_ShowOrderBook;
            View.ShowCurrencies += View_ShowCurrencies;
            View.ShowPairs += View_ShowPairs;
            View.ShowApiKeys += View_ShowApiKeys;
            View.ShowBalances += View_ShowBalances;
            View.ShowTrade += View_ShowPendingTrade;
            View.ShowTradingHistory += View_ShowTradingHistory;
            View.ShowBlowoutVolumeStrategy += View_ShowBlowoutVolumeStrategy;
            View.ShowCandlestickGraph += View_ShowCandlestickGraph;
            View.Exit += View_Exit;

            _model = model;
        }

        private void View_ShowTradingHistory()
        {
            var form = new TradingHistoryForm { MdiParent = View.MdiParentForm };

            var tradingHistoryPresenter = new TradingHistoryPresenter(form, new TradingHistoryModel(_model.DomainModel));

            tradingHistoryPresenter.Run();
        }

        private void View_ShowCandlestickGraph()
        {
            var form = new CandlestickForm { MdiParent = View.MdiParentForm };

            var candlestickPresenter = new CandlestickPresenter(form, new CandlestickModel(_model.DomainModel));

            candlestickPresenter.Run();
        }

        BlowoutVolumePresenter _blowoutVolumeStrategyPresenter;
        private void View_ShowBlowoutVolumeStrategy()
        {
            if (_blowoutVolumeStrategyPresenter == null)
            {
                var form = new BlowoutVolumeForm {MdiParent = View.MdiParentForm};
                _blowoutVolumeStrategyPresenter = new BlowoutVolumePresenter(form, new BlowoutVolumeModel(_model.DomainModel));
                _blowoutVolumeStrategyPresenter.Closed += () => _blowoutVolumeStrategyPresenter = null;
            }

            _blowoutVolumeStrategyPresenter.Run();
        }

        private void View_ShowPendingTrade()
        {
            var form = new TradeForm { MdiParent = View.MdiParentForm };

            var tradePresenter = new TradePresenter(form, new TradeModel(_model.DomainModel));

            tradePresenter.Run();
        }

        private void View_ShowApiKeys()
        {
            var form = new ApiKeyForm { MdiParent = View.MdiParentForm };

            var apiKeysPresenter = new ApiKeysPresenter(form, new ApiKeyModel(_model.DomainModel));

            apiKeysPresenter.Run();
        }

        private void View_ShowBalances()
        {
            var form = new BalanceForm { MdiParent = View.MdiParentForm };

            var balancesPresenter = new BalancePresenter(form, new BalanceModel(_model.DomainModel));

            balancesPresenter.Run();
        }

        private void View_Exit()
        {
            View.Close();
        }

        private void View_ShowCurrencies()
        {
            var form = new CurrencyForm { MdiParent = View.MdiParentForm };

            var currencyPresenter = new CurrencyPresenter(form, new CurrencyModel(_model.DomainModel));

            currencyPresenter.Run();
        }

        private void View_ShowPairs()
        {
            var form = new PairForm { MdiParent = View.MdiParentForm };

            var pairPresenter = new PairPresenter(form, new PairModel(_model.DomainModel));

            pairPresenter.Run();
        }

        private void View_ShowOrderBook()
        {
            var form = new OrderBookForm { MdiParent = View.MdiParentForm };

            var orderBookPresenter = new OrderBookPresenter(form, new OrderBookModel(_model.DomainModel));

            orderBookPresenter.Run();
        }
    }
}