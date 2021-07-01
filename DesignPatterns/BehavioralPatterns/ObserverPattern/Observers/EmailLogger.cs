using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ObserverPattern.Observers
{
    public class EmailLogger : IObserver
    {
        public bool IsEmailSent { get; private set; } = false;
        public void update(IExceptionHandler errorHandler)
        {
            var message = errorHandler.GetData();
            this.SendEmail(message);
        }

        private void SendEmail(string message)
        {
            // code to send email to team
            Console.WriteLine($"Email Sent with body '{message}'");
            this.IsEmailSent = true;
        }
    }
}
