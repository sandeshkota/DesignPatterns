using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategy;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern
{
    public interface ICustomerService
    {
        double GetInterestRate(int customerId, string typeOfLoan);
        void SetRatingStrategy(IRatingStrategy ratingStrategy);
        void SetInterestStrategy(IInterestRateStrategy interestStrategy);
        void SetDiscountStrategy(IDiscountStrategy discountStrategy);
    }
}
