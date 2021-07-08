using Xunit;
using DesignPatterns.StructuralPatterns.FacadePattern;
using System;

namespace DesignPatternTests.StructuralPatterns.FacadePattern
{
    [Trait("Pattern", "Structural")]
    public class FacadePatternTest
    {
        [Fact]
        public void BankAccount_Facade_Success_Test()
        {
            var bankAccountFacade = new BankAccountFacade(1234567890, 12345);

            bankAccountFacade.WithdrawCash(50.00);
            
            Assert.Equal(50.00, bankAccountFacade.GetAccountBalance());
        }

        [Fact]
        public void BankAccount_Facade_Failure_Test()
        {
            var bankAccountFacade = new BankAccountFacade(1234567890, 12345);

            void withdrawAmount() => bankAccountFacade.WithdrawCash(150.00);

            var exception = Assert.Throws<InvalidOperationException>(withdrawAmount);

            Assert.Equal("Invalid Operation", exception.Message);
        }
    }
}
