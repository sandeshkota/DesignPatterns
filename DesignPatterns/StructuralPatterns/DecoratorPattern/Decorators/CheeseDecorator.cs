using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.DecoratorPattern.Decorators
{
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(PizzaBase pizzaBase): base(pizzaBase)
        {
        }

        public override double GetCost()
        {
            return this.pizzaBase.GetCost() + 20;
        }

        public override string GetReciepe()
        {
            return this.pizzaBase.GetReciepe() + " + [Cheese] ";
        }
    }
}
