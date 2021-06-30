using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public class Address: ICloneable<Address>, IShallowCloneable<Address>
    {

        private char HouseNumberAppender = '#';

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
        public ZipCode ZipCode { get; set; }

        public Address ShallowClone()
        {
            return (Address)this.MemberwiseClone();
        }

        public Address DeepClone()
        {
            var clonedAddress = (Address)this.MemberwiseClone();
            clonedAddress.ZipCode = this.ZipCode.DeepClone();
            return clonedAddress;
        }
    }

    public class ZipCode: ICloneable<ZipCode>
    {
        public string Code { get; set; }

        public ZipCode DeepClone()
        {
            return (ZipCode)this.MemberwiseClone();
        }
    }
}
