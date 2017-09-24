using System.Collections.Generic;
using DomainModel.Features;

namespace Models.Interfaces
{
    public interface IBlowoutVolumeModel
    {
        IEnumerable<Market> Markets { get; }

        BlowoutVolumeSettings Settings { get; set; }

        void Release();

        void IncludePairToStrategy(PairOfMarket pair);
        void ExcludePairFromStrategy(PairOfMarket pair);
    }
}