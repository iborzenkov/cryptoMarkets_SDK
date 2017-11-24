using System;
using Presenters.Interfaces;
using Views.Interfaces;

namespace Presenters.Implementations
{
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; }

        protected BasePresenter(TView view)
        {
            View = view;
        }

        public void Run()
        {
            View.Show();
        }

        public event Action Closed;

        protected void OnClosed()
        {
            Closed?.Invoke();
        }
    }
}