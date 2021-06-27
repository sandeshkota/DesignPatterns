using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies
{
    public class FitchRatingStrategy: IRatingStrategy
    {
        public string GetCustomerRating(int customerId)
        {
            return "AAA";
        }
    }
}
