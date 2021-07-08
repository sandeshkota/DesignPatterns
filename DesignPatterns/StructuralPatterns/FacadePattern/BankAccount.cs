using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FacadePattern
{
    public class BankAccount
    {
        private double _accountBalance = 100.00;

        public double Getbalance()
        {
            return this._accountBalance;
        }

        public void DebitAmount(double amount)
        {
            this._accountBalance -= amount;
        }

        public bool IsFundsAvailable(double amount)
        {
            return (this._accountBalance >= amount);
        }
    }
}
