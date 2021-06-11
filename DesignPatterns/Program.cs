using DesignPatterns.BehavioralPatterns.StrategyPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            StrategyPattern();
            Console.WriteLine("Hello World!");
        }


        public static void StrategyPattern()
        {
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(new MoodyRatingStrategy());
            customerService.SetInterestStrategy(new HighInterestRateStrategy());
            customerService.SetDiscountStrategy(new DefaultDiscountStrategy());

            var customerInterestRate = customerService.GetInterestRate(123, "Home");

            Console.WriteLine($"The interest rate for customer is {customerInterestRate}");
        }

    }
}
