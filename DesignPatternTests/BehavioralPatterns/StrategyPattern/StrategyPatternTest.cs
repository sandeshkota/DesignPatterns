using DesignPatterns.BehavioralPatterns.StrategyPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;
using System;
using Xunit;

namespace DesignPatternTests.BehavioralPatterns.StrategyPattern
{
    public class StrategyPatternTest
    {
        [Theory]
        [InlineData("Moody", 5.4)]
        [InlineData("Sicra", 5.7)]
        [InlineData("Fitch", 4.8)]
        [InlineData("Crisil", 5.7)]
        public void Customer_Rating_Agency_Test(string ratingAgencyName, double expectedInterestRate)
        {
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(GetRatingStrategy(ratingAgencyName));
            customerService.SetInterestStrategy(GetInterestRateStrategy(String.Empty));
            customerService.SetDiscountStrategy(GetDiscountStrategy(String.Empty));

            var customerInterestRate = customerService.GetInterestRate(123, "Home");
            customerInterestRate = Math.Round(customerInterestRate, 2);

            Assert.True(customerInterestRate == expectedInterestRate, $"The rating logic is not correct");
        }

        [Theory]
        [InlineData("Default", 5.4)]
        [InlineData("High", 5.85)]
        public void Customer_Interest_Rate_Test(string interestRateBand, double expectedInterestRate)
        {
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(GetRatingStrategy(String.Empty));
            customerService.SetInterestStrategy(GetInterestRateStrategy(interestRateBand));
            customerService.SetDiscountStrategy(GetDiscountStrategy(String.Empty));

            var customerInterestRate = customerService.GetInterestRate(123, "Home");
            customerInterestRate = Math.Round(customerInterestRate, 2);

            Assert.True(customerInterestRate == expectedInterestRate, $"The rating logic is not correct");
        }

        [Theory]
        [InlineData("Home", 5.4)]
        [InlineData("Vehicle", 6.3)]
        [InlineData("Land", 7.2)]
        public void Customer_Loan_Type_Test(string typeOfLoan, double expectedInterestRate)
        {
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(GetRatingStrategy(String.Empty));
            customerService.SetInterestStrategy(GetInterestRateStrategy(String.Empty));
            customerService.SetDiscountStrategy(GetDiscountStrategy(String.Empty));

            var customerInterestRate = customerService.GetInterestRate(123, typeOfLoan);
            customerInterestRate = Math.Round(customerInterestRate, 2);

            Assert.True(customerInterestRate == expectedInterestRate, $"The rating logic is not correct");
        }


        #region Private Methods
        private IRatingStrategy GetRatingStrategy(string ratingAgencyName)
        {
            switch (ratingAgencyName.ToUpper())
            {
                case "MOODY":
                    return new MoodyRatingStrategy();
                case "CRISIL":
                    return new CrisilRatingStrategy();
                case "SICRA":
                    return new SicraRatingStrategy();
                case "FITCH":
                    return new FitchRatingStrategy();
                default:
                    return new MoodyRatingStrategy();
            }
        }

        private IInterestRateStrategy GetInterestRateStrategy(string interestRateBand)
        {
            switch (interestRateBand.ToUpper())
            {
                case "HIGH":
                    return new HighInterestRateStrategy();
                default:
                    return new DefaultInterestRateStrategy();
            }
        }

        private IDiscountStrategy GetDiscountStrategy(string discountStrategyName)
        {
            switch (discountStrategyName.ToUpper())
            {
                default:
                    return new DefaultDiscountStrategy();
            }
        }
        #endregion



    }
}
