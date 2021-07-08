using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FacadePattern
{
    class SecurityCodeValidator
    {
        private readonly int _validSecurityCode = 12345;
        public bool ValidateSecurityCode(int securityCode)
        {
            return (securityCode == this._validSecurityCode);
        }
    }
}
