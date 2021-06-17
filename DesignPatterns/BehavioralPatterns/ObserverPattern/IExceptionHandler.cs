using DesignPatterns.BehavioralPatterns.ObserverPattern.Observers;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns.ObserverPattern
{
    public interface IExceptionHandler
    {
        void RegisterObserver(IObserver observer);
        void UnRegisterObserver(IObserver observer);
        void Notify();
        string GetData();
    }
}
