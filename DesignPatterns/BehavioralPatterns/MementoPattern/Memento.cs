using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MementoPattern
{
    public class Memento
    {
        private readonly Photograph _photograph;

        public Memento(int brightnessLevel, List<string> filters)
        {
            var photograph = new Photograph { BrightnessLevel = brightnessLevel };
            filters.ForEach(f => photograph.AddFilter(f));
            this._photograph = photograph;
        }

        public Photograph GetSavedPhotograph()
        {
            return this._photograph;
        }

    }
}
