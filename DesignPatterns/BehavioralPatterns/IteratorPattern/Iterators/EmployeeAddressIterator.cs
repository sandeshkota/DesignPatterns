using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.IteratorPattern.Iterators
{
    class EmployeeAddressIterator : IAddressIterator
    {
        private readonly Employee _employee;
        private readonly int _totalAddresses = 2;
        private int _iterator = 1;

        public EmployeeAddressIterator(Employee employee)
        {
            this._employee = employee;
        }

        public bool HasAddress()
        {
            return _iterator <= _totalAddresses;
        }

        public Address GetAddress()
        {
            if (_iterator == 1)
                return GetFirstAddress();
            else if (_iterator == 2)
                return GetSecondAddress();
            else
                return null;
        }

        public void MoveToNextAddress()
        {
            _iterator++;
        }

       

        private Address GetFirstAddress()
        {
            return new Address
            {
                Name = this._employee.Name,
                BuildingNumber = this._employee.BuildingNumber1,
                StreetName = this._employee.Street1,
                City = this._employee.City1,
                State = this._employee.State1,
                Country = this._employee.Country1,
                ZipCode = this._employee.ZipCode1,
                PhoneNumber = this._employee.PhoneNumber1
            };
        }

        private Address GetSecondAddress()
        {
            return new Address
            {
                Name = this._employee.Name,
                BuildingNumber = this._employee.BuildingNumber2,
                StreetName = this._employee.Street2,
                City = this._employee.City2,
                State = this._employee.State2,
                Country = this._employee.Country2,
                ZipCode = this._employee.ZipCode2,
                PhoneNumber = this._employee.PhoneNumber2
            };
        }

    }
}
