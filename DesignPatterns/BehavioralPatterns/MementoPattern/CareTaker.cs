using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MementoPattern
{
    public class CareTaker
    {
        private List<Memento> _history = new();

        public void AddMemento(Memento memento)
        {
            this._history.Add(memento);
        }

        public Memento GetMemento(int index)
        {
            if (this._history.Count == 0)
                return default;

            return this._history.Count > index ? this._history[index] : default;
        }
    }
}
