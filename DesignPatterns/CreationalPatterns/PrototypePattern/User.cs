using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    public class User
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Address ResidentialAddress { get; set; }
        public Address CommunicationAddress { get; set; }

        public void CopyResidentialAddressToCommunicationAddress()
        {
            this.CommunicationAddress = this.ResidentialAddress.ShallowClone();
        }

        public void CopyCompleteResidentialAddressToCommunicationAddress()
        {
            this.CommunicationAddress = this.ResidentialAddress.DeepClone();
        }
    }
}
