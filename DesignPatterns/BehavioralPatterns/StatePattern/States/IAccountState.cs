using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StatePattern.States
{
    public interface IAccountState
    {
        void DepositMoney(double money);
        double WithdrawMoney(double money);

        string GetTypeOfAccount();

        void MoveToOpenedState();
        void MoveToClosedState();
        void MoveToWitheldState();
    }
}
