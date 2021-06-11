using System.Collections.Generic;
using DesignPatterns.BehavioralPatterns.StrategyPattern.Models;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
    }
}
