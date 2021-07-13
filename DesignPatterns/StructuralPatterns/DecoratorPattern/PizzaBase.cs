using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPattern
{
    public abstract class PizzaBase
    {
        public abstract string GetReciepe();
        public abstract double GetCost();
    }
}
