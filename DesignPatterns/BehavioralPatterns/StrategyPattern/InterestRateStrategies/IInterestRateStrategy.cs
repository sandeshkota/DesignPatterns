using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategy
{
    public interface IInterestRateStrategy
    {
        double GetInterestRate(string typeOfLoan);
    }
}
