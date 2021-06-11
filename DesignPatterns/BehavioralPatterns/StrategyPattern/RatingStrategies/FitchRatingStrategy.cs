using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies
{
    public class FitchRatingStrategy: IRatingStrategy
    {
        public string GetCustomerRating(int customerId)
        {
            // some logic and retuns the rating
            return "AAA"; // "BBB";
        }
    }
}
