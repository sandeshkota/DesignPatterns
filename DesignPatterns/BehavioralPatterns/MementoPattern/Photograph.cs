using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MementoPattern
{
    public class Photograph
    {
        public int BrightnessLevel { get; set; } = 50;
        private PhotographFilters _filters = new PhotographFilters();

        public void AddFilter(string filter)
        {
            this._filters.Filters.Add(filter);
        }

        public List<string> GetFilters()
        {
            return this._filters.Filters;
        }
    }


    public class PhotographFilters
    {
        public List<string> Filters { get; set; } = new();
    }
}
