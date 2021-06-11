using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategies
{
    public class DefaultDiscountStrategy : IDiscountStrategy
    {
        public double GetDiscount(string rating)
        {
            switch (rating)
            {
                case "AAA":
                    return 0.20;
                case "BBB":
                    return 0.10;
                case "CCC":
                    return 0.05;
                default:
                    return 0.00;
            }
        }
    }
}
