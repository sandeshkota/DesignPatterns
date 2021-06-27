using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MediatorPattern
{
    public class Visitor: IVisitor
    {
        private IChatRoom _chatRoom;
        public string Name { get; private set; }
        public int TotalMessagesSent { get; private set; }
        public int TotalMessagesRecieved { get; private set; }

        public Visitor(string name)
        {
            Name = name;
        }

        public void Send(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} -----> {message}");
            _chatRoom.Send(message, this);
            TotalMessagesSent++;
        }

        public void Recieve(string message, IVisitor sender)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} <----- {message}  (from {sender.Name})");
            TotalMessagesRecieved++;
        }


        public void Enter(IChatRoom chatRoom)
        {
            chatRoom.Register(this);
            _chatRoom = chatRoom;
        }

        public void Leave()
        {
            if (_chatRoom != null)
            {
                _chatRoom.UnRegister(this);
                _chatRoom = null;
            }
        }
    }
}
