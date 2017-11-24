using System;
using System.Collections.Generic;
using DomainModel;
using DomainModel.Features;
using Models;

namespace Views.Interfaces
{
    public interface IBlowoutVolumeView : IView
    {
        void SetTimeframes(TimeframeType[] timeframes);
        void SetMarkets(IEnumerable<Market> markets);
        void SetPairs(IEnumerable<PairOfMarket> pairs);
        
        event Action<Market> MarketChanged;

        event Action<BlowoutVolumeSettings> SettingsChanged;
        void SetSettings(BlowoutVolumeSettings settings);

        event Action<PairOfMarket, TimeframeType, int> AddPairToAnalise;
        event Action<PairOfMarket, TimeframeType, int> RemovePairFromAnalise;

        void PairWasAddedToAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount);
        void PairWasRemovedFromAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount);
        //void ReplaceAnalisingPairs(IEnumerable<PairOfMarket, TimeframeType, int> );

        void SaveAnalisePairs();
        void LoadAnalisePairs();

        void SignalOccured(PairOfMarket pair);
        void SignalDisappeared(PairOfMarket pair);
    }
}