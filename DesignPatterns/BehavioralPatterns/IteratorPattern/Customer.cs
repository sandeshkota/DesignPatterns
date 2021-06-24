using DesignPatterns.BehavioralPatterns.IteratorPattern.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.IteratorPattern
{
    public class Customer : IAddressEnumerable
    {
        public string Name { get; set; }

        // Lets assume that the address is stored in the format: BuildingNumber, StreetName, City, State, Country, ZipCode, PhoneNumber
        public List<string> Address { get; set; } = new();

        public IAddressIterator GetAddressIterator()
        {
            return new CustomerAddressIterator(this);
        }
    }
}
