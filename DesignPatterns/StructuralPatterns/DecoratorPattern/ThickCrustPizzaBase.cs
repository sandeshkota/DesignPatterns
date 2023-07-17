using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPattern
{
    public class ThickCrustPizzaBase : PizzaBase
    {
        public override double GetCost()
        {
            return 100;
        }
        
        public override string GetReciepe()
        {
            return "Pizza = [Thick Crust] ";
        }
    }
}
