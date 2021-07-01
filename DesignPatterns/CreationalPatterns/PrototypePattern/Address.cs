using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public class Address: ICloneable<Address>, IShallowCloneable<Address>
    {

        private readonly char HouseNumberAppender = '#';

        private string _houseNumber;
        public string HouseNumber {
            get { 
                return this._houseNumber;
            }
            set {
                this._houseNumber = $"{this.HouseNumberAppender}{value}";
            }
        }

        public string Street { get; set; }
        public string City { get; set; }
        public Contact Contact { get; set; }

        public Address ShallowClone()
        {
            return (Address)this.MemberwiseClone();
        }

        public Address DeepClone()
        {
            var clonedAddress = (Address)this.MemberwiseClone();
            clonedAddress.Contact = this.Contact.DeepClone();
            return clonedAddress;
        }
    }

    public class Contact : ICloneable<Contact>
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }

        public Contact DeepClone()
        {
            return (Contact)this.MemberwiseClone();
        }
    }
}
