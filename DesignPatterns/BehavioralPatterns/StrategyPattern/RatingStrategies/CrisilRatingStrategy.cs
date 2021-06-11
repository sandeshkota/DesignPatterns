﻿using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies
{
    public class CrisilRatingStrategy : IRatingStrategy
    {
        public string GetCustomerRating(int customerId)
        {
            // some logic and retuns the rating
            return "CCC"; // "AAA";
        }
    }
}
