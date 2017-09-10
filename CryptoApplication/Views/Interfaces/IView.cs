using System;

namespace Views.Interfaces
{
    public interface IView
    {
        void Show();

        void Close();

        event Action ViewClosed;
    }
}