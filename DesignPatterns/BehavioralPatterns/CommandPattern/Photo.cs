using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class Photo
    {
        public int BrightnessLevel { get; set; } = 50;
        public List<string> Filters { get; set; } = new();
    }
}
