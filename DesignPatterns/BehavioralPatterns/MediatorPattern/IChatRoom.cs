using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MediatorPattern
{
    public interface IChatRoom
    {
        void Send(string message, Visitor sender);
        void Register(Visitor visitor);
        void UnRegister(Visitor visitor);
    }
}
