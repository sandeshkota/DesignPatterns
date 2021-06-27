using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies
{
    public class SicraRatingStrategy : IRatingStrategy
    {

        public string GetCustomerRating(int customerId)
        {
            return "DDD";
        }

    }
}
