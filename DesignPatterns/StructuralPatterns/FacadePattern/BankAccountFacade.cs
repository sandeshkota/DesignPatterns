using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FacadePattern
{
    public class BankAccountFacade
    {
        private readonly int _accountNumber;
        private readonly int _securityCode;
        private AccountValidator _accountValidator;
        private SecurityCodeValidator _securityCodeValidator;
        private BankAccount _bankAccount;

        public BankAccountFacade(int accountNumber, int securityCode)
        {
            this._accountNumber = accountNumber;
            this._securityCode = securityCode;

            this._accountValidator = new AccountValidator();
            this._securityCodeValidator = new SecurityCodeValidator();
            this._bankAccount = new BankAccount();
        }


        public void WithdrawCash(double amount)
        {
            if(this._accountValidator.ValidateAccountNumber(this._accountNumber)
                && this._securityCodeValidator.ValidateSecurityCode(this._securityCode) 
                && this._bankAccount.IsFundsAvailable(amount) )
            {
                this._bankAccount.DebitAmount(amount);
            }
            else 
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            
        }

        public double GetAccountBalance()
        {
            return this._bankAccount.Getbalance();
        }

    }
}
