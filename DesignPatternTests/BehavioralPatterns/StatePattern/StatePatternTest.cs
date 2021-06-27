using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DesignPatterns.BehavioralPatterns.StatePattern;

namespace DesignPatternTests.BehavioralPatterns.StatePattern
{
    public class StatePatternTest
    {

        public class OpenedAccountStatePatternTest
        {
            [Fact]
            public void Opened_Account_Add_Money_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.AddMoney(200);

                Assert.Equal(300.00, account.GetAccountBalance());
            }

            [Fact]
            public void Opened_Account_Get_Money_Success_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.AddMoney(200);
                account.GetMoney(150);

                Assert.Equal(150.00, account.GetAccountBalance());
            }

            [Fact]
            public void Opened_Account_Get_Money_Failure_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);

                Action getMoney = () => account.GetMoney(150);

                var exception = Assert.Throws<InvalidOperationException>(getMoney);
                Assert.Equal("Insufficient Funds in the account", exception.Message);
            }

            [Fact]
            public void Opened_Account_To_Closed_Account_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToClosedState();

                Assert.Equal("CLOSED", account.GetAccountType());
            }

            [Fact]
            public void Opened_Account_To_Withheld_Account_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToWithheldState();

                Assert.Equal("WITHHELD", account.GetAccountType());
            }
        }

        public class ClosedAccountStatePatternTest
        {

            [Fact]
            public void Closed_Account_Add_Money_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToClosedState();

                Action addMoney = () => account.AddMoney(150);

                var exception = Assert.Throws<InvalidOperationException>(addMoney);
                Assert.Equal("Cannot deposit money into a Closed account", exception.Message);
            }

            [Fact]
            public void Closed_Account_Get_Money_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToClosedState();

                Action getMoney = () => account.GetMoney(50);

                var exception = Assert.Throws<InvalidOperationException>(getMoney);
                Assert.Equal("Cannot withdraw money from a Closed account", exception.Message);
            }

            [Fact]
            public void Closed_Account_To_Opened_Account_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToClosedState();
                account.ChangeToOpenedState();

                Assert.Equal("OPENED", account.GetAccountType());
            }

            [Fact]
            public void Closed_Account_To_Withheld_Account_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToClosedState();

                Action changeToWithheldState = () => account.ChangeToWithheldState();

                var exception = Assert.Throws<InvalidOperationException>(changeToWithheldState);
                Assert.Equal("Cannot move account from closed state to withheld state", exception.Message);
            }

        }

        public class WithheldAccountStatePatternTest
        {

            [Fact]
            public void Withheld_Account_Add_Money_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToWithheldState();
                account.AddMoney(200);

                Assert.Equal(300.00, account.GetAccountBalance());
            }

            [Fact]
            public void Withheld_Account_Get_Money_Success_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToWithheldState();
                account.AddMoney(200);
                account.GetMoney(100);

                Assert.Equal(200.00, account.GetAccountBalance());
            }

            [Fact]
            public void Withheld_Account_Get_Money_Withdraw_Limit_Failure_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToWithheldState();
                account.AddMoney(200);

                Action getMoney = () => account.GetMoney(150);

                var exception = Assert.Throws<InvalidOperationException>(getMoney);
                Assert.Equal("Withdraw limit is only 100 for this account", exception.Message);
            }

            [Fact]
            public void Withheld_Account_Get_Money_Failure_Test()
            {
                var account = new Account("1900675342", "BANK000765", 50.00);
                account.ChangeToWithheldState();

                Action getMoney = () => account.GetMoney(80);

                var exception = Assert.Throws<InvalidOperationException>(getMoney);
                Assert.Equal("Insufficient Funds in the account", exception.Message);
            }

            [Fact]
            public void Withheld_Account_To_Opened_Account_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToWithheldState();
                account.ChangeToOpenedState();

                Assert.Equal("OPENED", account.GetAccountType());
            }

            [Fact]
            public void Withheld_Account_To_Closed_Account_Test()
            {
                var account = new Account("1900675342", "BANK000765", 100.00);
                account.ChangeToWithheldState();
                account.ChangeToClosedState();

                Assert.Equal("CLOSED", account.GetAccountType());
            }

        }


    }
}
