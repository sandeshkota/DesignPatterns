using DesignPatterns.BehavioralPatterns.StrategyPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;


namespace DesignPatterns.BehavioralPatterns.StrategyPattern
{
    public class CustomerService : ICustomerService
    {
        #region Constructor and Members
        IRatingStrategy _ratingStrategy;
        IInterestRateStrategy _interestStrategy;
        IDiscountStrategy _discountStrategy;
        private const double MINIMUM_INTEREST_DATE = 5.00;
        #endregion

        public double GetInterestRate(int customerId, string typeOfLoan)
        {
            var interestRate = MINIMUM_INTEREST_DATE + GetInterestRate(typeOfLoan);
            var customerRating = GetCustomerRating(customerId);
            var discount = GetDiscount(customerRating);
            return interestRate * (1 - discount);
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }
        private double GetDiscount(string rating)
        {
            return _discountStrategy.GetDiscount(rating);
        }

        public void SetInterestStrategy(IInterestRateStrategy interestStrategy)
        {
            _interestStrategy = interestStrategy;
        }
        private double GetInterestRate(string typeOfLoan)
        {
            return _interestStrategy.GetInterestRate(typeOfLoan);
        }

        public void SetRatingStrategy(IRatingStrategy ratingStrategy)
        {
            _ratingStrategy = ratingStrategy;
        }
        private string GetCustomerRating(int customerId)
        {
            return _ratingStrategy.GetCustomerRating(customerId);
        }

    }
}
