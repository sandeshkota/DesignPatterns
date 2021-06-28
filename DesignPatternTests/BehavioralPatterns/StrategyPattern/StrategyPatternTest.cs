using DesignPatterns.BehavioralPatterns.StrategyPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategy;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DesignPatternTests.BehavioralPatterns.StrategyPattern
{
    [Trait("Pattern", "Behavioral")]
    public class StrategyPatternTest
    {
        [Theory]
        [MemberData(nameof(RatingAgencyData))]
        public void Customer_Rating_Agency_Test(string ratingAgencyName, double expectedInterestRate)
        {
            // arrange
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(GetRatingStrategy(ratingAgencyName));
            customerService.SetInterestStrategy(GetInterestRateStrategy(String.Empty));
            customerService.SetDiscountStrategy(GetDiscountStrategy(String.Empty));

            // act
            var customerInterestRate = customerService.GetInterestRate(123, "Home");
            customerInterestRate = Math.Round(customerInterestRate, 2);

            // assert
            Assert.Equal(expectedInterestRate, customerInterestRate);
        }

        [Theory]
        [InlineData("Default", "Home", 5.4)]
        [InlineData("High", "Home", 5.85)]
        [InlineData("Default", "Vehicle", 6.3)]
        [InlineData("High", "Vehicle", 6.75)]
        [InlineData("Default", "Land", 7.2)]
        [InlineData("High", "Land", 7.2)]
        public void Customer_Interest_Rate_Test(string interestRateBand, string typeOfLoan, double expectedInterestRate)
        {
            // arrange
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(GetRatingStrategy(String.Empty));
            customerService.SetInterestStrategy(GetInterestRateStrategy(interestRateBand));
            customerService.SetDiscountStrategy(GetDiscountStrategy(String.Empty));

            // act
            var customerInterestRate = customerService.GetInterestRate(123, typeOfLoan);
            customerInterestRate = Math.Round(customerInterestRate, 2);

            // assert
            Assert.Equal(expectedInterestRate, customerInterestRate);
        }

        [Theory]
        [MemberData(nameof(GetLoanTypeData), parameters:3)]
        public void Customer_Loan_Type_Test(string typeOfLoan, double expectedInterestRate)
        {
            // arrange
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(GetRatingStrategy(String.Empty));
            customerService.SetInterestStrategy(GetInterestRateStrategy(String.Empty));
            customerService.SetDiscountStrategy(GetDiscountStrategy(String.Empty));

            // act
            var customerInterestRate = customerService.GetInterestRate(123, typeOfLoan);
            customerInterestRate = Math.Round(customerInterestRate, 2);

            // assert
            Assert.Equal(expectedInterestRate, customerInterestRate);
        }


        #region Private Methods

        public static IEnumerable<object[]> RatingAgencyData =>
               new List<object[]>
               {
                    new object[] { "Moody", 5.4 },
                    new object[] { "Sicra", 6 },
                    new object[] { "Fitch", 4.8 },
                    new object[] { "Crisil", 5.7 },
               };

        public static IEnumerable<object[]> GetLoanTypeData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] { "Home", 5.4 },
                new object[] { "Vehicle", 6.3 },
                new object[] { "Land", 7.2 }
            };

            return allData.Take(numTests);
        }

        private static IRatingStrategy GetRatingStrategy(string ratingAgencyName)
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

        private static IInterestRateStrategy GetInterestRateStrategy(string interestRateBand)
        {
            switch (interestRateBand.ToUpper())
            {
                case "HIGH":
                    return new HighInterestRateStrategy();
                default:
                    return new DefaultInterestRateStrategy();
            }
        }

        private static IDiscountStrategy GetDiscountStrategy(string discountStrategyName)
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
