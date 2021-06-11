using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategy
{
    public interface IDiscountStrategy
    {
        double GetDiscount(string rating);
    }
}
