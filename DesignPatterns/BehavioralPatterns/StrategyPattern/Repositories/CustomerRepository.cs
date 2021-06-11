using System.Collections.Generic;
using DesignPatterns.BehavioralPatterns.StrategyPattern.Models;

namespace DesignPatterns.BehavioralPatterns.StrategyPattern.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        
        public List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Vijay Malya", location = "UK" },
                new Customer { Id = 2, Name = "Mehul Chowski", location = "Antigua" },
                new Customer { Id = 3, Name = "Elon Musk", location = "US" },
                new Customer { Id = 4, Name = "Sandesh Kota", location = "India" }
            };
        }

    }
}
