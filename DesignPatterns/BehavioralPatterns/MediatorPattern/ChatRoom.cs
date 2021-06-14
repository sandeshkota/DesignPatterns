using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MediatorPattern
{
    public class ChatRoom : IChatRoom
    {
        private List<IVisitor> _activeVisitors = new();

        public void Send(string message, Visitor sender)
        {
            foreach (var visitor in _activeVisitors)
            {
                if(visitor != sender)
                {
                    visitor.Recieve(message, sender);
                }
            }
        }

        public void Register(Visitor visitor)
        {
            _activeVisitors.Add(visitor);
        }

        public void UnRegister(Visitor visitor)
        {
            _activeVisitors.Remove(visitor);
        }
    }
}
