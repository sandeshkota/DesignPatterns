using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MediatorPattern
{
    public interface IVisitor
    {
        public string Name { get; }
        void Recieve(string message, IVisitor sender);
        void Leave();
    }
}
