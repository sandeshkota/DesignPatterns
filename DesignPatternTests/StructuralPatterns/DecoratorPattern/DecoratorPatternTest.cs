using Xunit;
using DesignPatterns.StructuralPatterns.DecoratorPattern;
using DesignPatterns.StructuralPatterns.DecoratorPattern.Decorators;

namespace DesignPatternTests.StructuralPatterns.DecoratorPattern
{
    [Trait("Pattern", "Structural")]
    public class DecoratorPatternTest
    {
        [Fact]
        public void ThinCrust_Pizza_Test()
        {
            var myPizza = new ThinCrustPizzaBase();

            var reciepe = myPizza.GetReciepe();
            var cost = myPizza.GetCost();

            Assert.Equal("Pizza = [Thin Crust] ", reciepe);
            Assert.Equal(120, cost);
        }

        [Fact]
        public void ThickCrust_Pizza_Test()
        {
            var myPizza = new ThickCrustPizzaBase();

            var reciepe = myPizza.GetReciepe();
            var cost = myPizza.GetCost();

            Assert.Equal("Pizza = [Thick Crust] ", reciepe);
            Assert.Equal(100, cost);
        }

        [Fact]
        public void Jalapeno_Onion_Cheese_ThinCrust_Pizza_Test()
        {
            var myPizza = new ThinCrustPizzaBase();
            var myCheesePizza = new CheeseDecorator(myPizza);
            var myCheeseOnionPizza = new OnionDecorator(myCheesePizza);
            var myCheeseOnionJalapenoPizza = new JalapenoDecorator(myCheeseOnionPizza);

            var reciepe = myCheeseOnionJalapenoPizza.GetReciepe();
            var cost = myCheeseOnionJalapenoPizza.GetCost();

            Assert.Equal("Pizza = [Thin Crust]  + [Cheese]  + [Onion]  + [Jalapeno] ", reciepe);
            Assert.Equal(155, cost);
        }

        [Fact]
        public void Jalapeno_Cheese_ThickCrust_Pizza_Test()
        {
            var myPizza = new ThickCrustPizzaBase();
            var myCheesePizza = new CheeseDecorator(myPizza);
            var myCheeseJalapenoPizza = new JalapenoDecorator(myCheesePizza);

            var reciepe = myCheeseJalapenoPizza.GetReciepe();
            var cost = myCheeseJalapenoPizza.GetCost();

            Assert.Equal("Pizza = [Thick Crust]  + [Cheese]  + [Jalapeno] ", reciepe);
            Assert.Equal(130, cost);
        }
    }
}
