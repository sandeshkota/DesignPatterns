using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategy
{
    public interface IRatingStrategy
    {
        string GetCustomerRating(int customerId);
    }
}
