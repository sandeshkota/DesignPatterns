using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ObserverPattern.Observers
{
    public class TableLogger : IObserver
    {
        public bool IsSavedToDB = false;

        public void update(IExceptionHandler errorHandler)
        {
            var message = errorHandler.GetData();
            this.LogToDB(message);
        }

        private void LogToDB(string message)
        {
            // code to Log to DB
            Console.WriteLine($"Table entry made with message '{message}'");
            this.IsSavedToDB = true;
        }
    }
}
