using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPattern.Decorators
{
    public class JalapenoDecorator : PizzaDecorator
    {
        public JalapenoDecorator(PizzaBase pizzaBase) : base(pizzaBase)
        {
        }

        public override double GetCost()
        {
            return this.pizzaBase.GetCost() + 10;
        }

        public override string GetReciepe()
        {
            return this.pizzaBase.GetReciepe() + " + [Jalapeno] ";
        }
    }
}
