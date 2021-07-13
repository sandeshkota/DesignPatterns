using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPattern
{
    public class ThinCrustPizzaBase : PizzaBase
    {
        public override double GetCost()
        {
            return 120;
        }

        public override string GetReciepe()
        {
            return "Pizza = [Thin Crust] ";
        }
    }
}
