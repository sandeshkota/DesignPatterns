using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ObserverPattern.Observers
{
    public interface IObserver
    {
        void update(IExceptionHandler errorHandler);
    }
}
