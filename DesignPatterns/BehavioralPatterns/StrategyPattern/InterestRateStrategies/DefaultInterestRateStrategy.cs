using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategies
{
    public class DefaultInterestRateStrategy: IInterestRateStrategy
    {
        public double GetInterestRate(string typeOfLoan)
        {
            switch (typeOfLoan)
            {
                case "Home":
                    return 1.00;
                case "Vehicle":
                    return 2.00;
                default:
                    return 3.00;
            }
        }

    }
}
