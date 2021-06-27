using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MementoPattern
{
    public class Originator
    {

        private Photograph _photograph;

        public void SetPhotograph(Photograph photograph)
        {
            this._photograph = photograph;
        }

        public Memento SaveToMemento(Photograph photograph)
        {
            return new Memento(photograph.BrightnessLevel, photograph.GetFilters());
        }

        public Photograph RestroreFromMemento(Memento memento)
        {
            return memento.GetSavedPhotograph();
        }
    }
}
