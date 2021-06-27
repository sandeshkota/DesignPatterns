using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.BehavioralPatterns.CommandPattern.Commands;

namespace DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class EditorCommandHistory
    {
        private readonly List<ICommand> _commandHistory;
        public EditorCommandHistory()
        {
            _commandHistory = new List<ICommand>();
        }

        public void Push(ICommand command)
        {
            this._commandHistory.Add(command);
        }

        public ICommand Pop()
        {
            if(this._commandHistory.Count > 0)
            {
                var lastCommand = this._commandHistory.Last();
                this._commandHistory.RemoveAt(this._commandHistory.Count - 1);
                return lastCommand;
            }
            return null;
        }
    }
}
