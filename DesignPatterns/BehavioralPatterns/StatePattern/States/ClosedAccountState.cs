﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StatePattern.States
{
    public class ClosedAccountState: IAccountState
    {
        private readonly Account _account;
        public ClosedAccountState(Account account)
        {
            this._account = account;
        }

        public string GetTypeOfAccount()
        {
            return "CLOSED";
        }


        public void DepositMoney(double money)
        {
            throw new InvalidOperationException("Cannot deposit money into a Closed account");
        }

        public double WithdrawMoney(double money)
        {
            throw new InvalidOperationException("Cannot withdraw money from a Closed account");
        }

        public void MoveToClosedState()
        {
            // Do nothing because the account is already in Closed State
        }

        public void MoveToOpenedState()
        {
            this._account.ChangeState(new OpenedAccountState(this._account));
        }

        public void MoveToWithheldState()
        {
            throw new InvalidOperationException("Cannot move account from closed state to withheld state");
        }
    }
}
