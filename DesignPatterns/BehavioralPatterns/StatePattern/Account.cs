using System;
using DesignPatterns.BehavioralPatterns.StatePattern.States;

namespace DesignPatterns.BehavioralPatterns.StatePattern
{
    public class Account : IAccount
    {
        // TODO :: change access modifier
        public double _balance;
        private readonly string _number;
        private readonly string _ifscCode;
        private IAccountState _accountState;

        public Account(string number, string ifscCode, double initialBalance)
        {
            this._number = number;
            this._ifscCode = ifscCode;
            this._balance = initialBalance;
            this._accountState = new OpenedAccountState(this);
        }

        public void AddMoney(double money)
        {
            Console.WriteLine($"Adding {money}");
            this._accountState.DepositMoney(money);
        }

        public double GetMoney(double money)
        {
            Console.WriteLine($"Getting {money}");
            return this._accountState.WithdrawMoney(money);
        }

        public void ChangeState(IAccountState accountState)
        {
            this._accountState = accountState;
        }

        public string GetAccountType()
        {
            return this._accountState.GetTypeOfAccount();
        }

        public double GetAccountBalance()
        {
            return this._balance;
        }

        public string GetAccountDetails()
        {
            return $"Account Number: {this._number} | Balance: {this.GetAccountBalance()} | IFSC: {this._ifscCode}";
        }
        
        public void ChangeToOpenedState()
        {
            this._accountState.MoveToOpenedState();
        }

        public void ChangeToClosedState()
        {
            this._accountState.MoveToClosedState();
        }

        public void ChangeToWithheldState()
        {
            this._accountState.MoveToWithheldState();
        }
    }
}
