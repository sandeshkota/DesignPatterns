using DesignPatterns.BehavioralPatterns.IteratorPattern.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.IteratorPattern
{
    public class Employee : IAddressEnumerable
    {
        public string Name { get; set; }


        public string BuildingNumber1 { get; set; }
        public string Street1 { get; set; }
        public string City1 { get; set; }
        public string State1 { get; set; }
        public string Country1 { get; set; }
        public string ZipCode1 { get; set; }
        public string PhoneNumber1 { get; set; }


        public string BuildingNumber2 { get; set; }
        public string Street2 { get; set; }
        public string City2 { get; set; }
        public string State2 { get; set; }
        public string Country2 { get; set; }
        public string ZipCode2 { get; set; }
        public string PhoneNumber2 { get; set; }


        public IAddressIterator GetAddressIterator()
        {
            return new EmployeeAddressIterator(this);
        }
    }
}
