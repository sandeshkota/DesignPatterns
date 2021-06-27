using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StatePattern.States
{
    public class OpenedAccountState : IAccountState
    {
        private Account _account;
        public OpenedAccountState(Account account)
        {
            this._account = account;
        }

        public string GetTypeOfAccount()
        {
            return "OPENED";
        }

        public void DepositMoney(double money)
        {
            this._account._balance += money;
        }

        public double WithdrawMoney(double money)
        {
            if(this._account._balance >= money)
            {
                this._account._balance -= money;
                return money;
            }

            throw new InvalidOperationException("Insufficient Funds in the account");
        }

        public void MoveToClosedState()
        {
            this._account.ChangeState(new ClosedAccountState(this._account));
        }

        public void MoveToOpenedState()
        {
            
        }

        public void MoveToWitheldState()
        {
            this._account.ChangeState(new WithheldAccountState(this._account));
        }

        
    }
}
