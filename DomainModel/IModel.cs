using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel
{
    public interface IModel
    {
        IEnumerable<Market> Markets { get; }
    }
}