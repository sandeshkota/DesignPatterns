using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StatePattern
{
    public interface IAccount
    {
        void AddMoney(double money);

        double GetMoney(double money);

        string GetAccountType();

        string GetAccountDetails();
        double GetAccountBalance();

        void ChangeToOpenedState();
        void ChangeToClosedState();
        void ChangeToWithheldState();
    }
}
