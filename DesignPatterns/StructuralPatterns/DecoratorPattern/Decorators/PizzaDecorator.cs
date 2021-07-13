using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.StructuralPatterns.DecoratorPattern;

namespace DesignPatterns.StructuralPatterns.DecoratorPattern.Decorators
{
    public abstract class PizzaDecorator : PizzaBase
    {
        protected readonly PizzaBase pizzaBase;
        protected PizzaDecorator(PizzaBase pizzaBase)
        {
            this.pizzaBase = pizzaBase;
        }
    }
}
