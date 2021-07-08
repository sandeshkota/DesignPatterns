using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FacadePattern
{
    public class AccountValidator
    {
        private readonly int _validAccountNumber = 1234567890;
        public bool ValidateAccountNumber(int accountNumber)
        {
            return (accountNumber == this._validAccountNumber);
        }
    }
}
