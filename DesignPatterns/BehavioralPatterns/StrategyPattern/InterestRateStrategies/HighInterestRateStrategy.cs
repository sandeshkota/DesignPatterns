﻿using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategies
{
    public class HighInterestRateStrategy: IInterestRateStrategy
    {
        public double GetInterestRate(string typeOfLoan)
        {
            switch (typeOfLoan.ToUpper())
            {
                case "HOME":
                    return 1.50;
                case "VEHICLE":
                    return 2.50;
                default:
                    return 3.00;
            }
        }

    }
}
