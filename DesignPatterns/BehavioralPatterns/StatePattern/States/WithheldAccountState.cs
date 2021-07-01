using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StatePattern.States
{
    public class WithheldAccountState: IAccountState
    {
        private readonly double _withdrawLimit = 100.00;
        private readonly Account _account;
        public WithheldAccountState(Account account)
        {
            this._account = account;
        }

        public string GetTypeOfAccount()
        {
            return "WITHHELD";
        }


        public void DepositMoney(double money)
        {
            this._account.Balance += money;
        }

        public double WithdrawMoney(double money)
        {
            if(this._withdrawLimit >= money) { 
                if (this._account.Balance >= money)
                {
                    this._account.Balance -= money;
                    return money;
                }

                throw new InvalidOperationException("Insufficient Funds in the account");
            }
            throw new InvalidOperationException($"Withdraw limit is only {this._withdrawLimit} for this account");
        }

        public void MoveToClosedState()
        {
            this._account.ChangeState(new ClosedAccountState(this._account));
        }

        public void MoveToOpenedState()
        {
            this._account.ChangeState(new OpenedAccountState(this._account));
        }

        public void MoveToWithheldState()
        {
            // Do nothing because the account is already in Withheld State
        }
    }
}
