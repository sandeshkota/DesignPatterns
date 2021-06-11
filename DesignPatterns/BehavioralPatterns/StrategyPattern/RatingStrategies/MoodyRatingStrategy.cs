using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies
{
    public class MoodyRatingStrategy : IRatingStrategy
    {
        public string GetCustomerRating(int customerId)
        {
            // some logic and retuns the rating
            return "BBB"; // "BBB";
        }
    }
}
