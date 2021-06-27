using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies
{
    public class MoodyRatingStrategy : IRatingStrategy
    {
        public string GetCustomerRating(int customerId)
        {
            return "BBB";
        }
    }
}
