using DesignPatterns.BehavioralPatterns.ObserverPattern.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ObserverPattern
{
    public class ExceptionHandler : IExceptionHandler
    {
        private string _exceptionMessage = "Generic Exception Message";
        private List<IObserver> _observers { get; set; } = new();

        public void Notify()
        {
            this._observers.ForEach(o => o.update(this));
        }

        public void RegisterObserver(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void UnRegisterObserver(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public string GetData()
        {
            return _exceptionMessage;
        }

        public void HandleException(string message)
        {
            this._exceptionMessage = message;
            this.Notify();
        }
    }
}
