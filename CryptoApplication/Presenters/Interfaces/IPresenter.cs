using System;

namespace Presenters.Interfaces
{
    public interface IPresenter
    {
        void Run();

        event Action Closed;
    }
}