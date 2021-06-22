using DesignPatterns.BehavioralPatterns.CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class PhotoEditor
    {
        private EditorCommandHistory _commandHistory;
        private IncreaseBrightnessCommand _increaseBrightnessCommand;
        private DecreaseBrightnessCommand _decreaseBrightnessCommand;
        private AddVividFilterCommand _addVividFilterCommand;
        private RemoveVividFilterCommand _removeVividFilterCommand;

        public PhotoEditor(IncreaseBrightnessCommand increaseBrightnessCommand,
                            DecreaseBrightnessCommand decreaseBrightnessCommand,
                            AddVividFilterCommand addVividFilterCommand,
                            RemoveVividFilterCommand removeVividFilterCommand)
        {
            this._increaseBrightnessCommand = increaseBrightnessCommand;
            this._decreaseBrightnessCommand = decreaseBrightnessCommand;
            this._addVividFilterCommand = addVividFilterCommand;
            this._removeVividFilterCommand = removeVividFilterCommand;
            this._commandHistory = new EditorCommandHistory();
        }


        public void IncreaseBrightness()
        {
            this._increaseBrightnessCommand.Execute();
            _commandHistory.Push(this._increaseBrightnessCommand);
        }

        public void DecreaseBrightness()
        {
            this._decreaseBrightnessCommand.Execute();
            _commandHistory.Push(this._decreaseBrightnessCommand);
        }

        public void AddVividFilter()
        {
            this._addVividFilterCommand.Execute();
            _commandHistory.Push(this._addVividFilterCommand);
        }

        public void RemoveVividFilter()
        {
            this._removeVividFilterCommand.Execute();
            _commandHistory.Push(this._removeVividFilterCommand);
        }

        public void Undo()
        {
            var lastCommand = this._commandHistory.Pop();
            if(lastCommand != null)
            {
                lastCommand.UnExecute();
            } else
            {
                Console.WriteLine("There are no commands to Undo");
            }
            
        }
    }
}
