using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.IteratorPattern.Iterators
{
    public class CustomerAddressIterator : IAddressIterator
    {
        private readonly Customer _customer;
        private readonly List<string> _addresses;
        private readonly int _totalAddresses = 0;
        private int _iterator = 0;

        public CustomerAddressIterator(Customer customer)
        {
            this._customer = customer;
            this._addresses = this._customer.Address;
            this._totalAddresses = this._addresses.Count;
        }

        
        public bool HasAddress()
        {
            return _iterator < _totalAddresses;
        }
        public Address GetAddress()
        {
            if (_iterator < _totalAddresses)
            {
                var _customerAddress = this._addresses[_iterator];
                var address = ParseAddress(_customerAddress);
                address.Name = this._customer.Name;
                return address;
            }

            return null;
        }

        public void MoveToNextAddress()
        {
            _iterator++;
        }

        private static Address ParseAddress(string address)
        {
            var addressArray = address.Split(',');
            return new Address
            {
                BuildingNumber = addressArray[0],
                StreetName = addressArray[1],
                City = addressArray[2],
                State = addressArray[3],
                Country = addressArray[4],
                ZipCode = addressArray[5],
                PhoneNumber = addressArray[6]
            };
        }

    }
}
