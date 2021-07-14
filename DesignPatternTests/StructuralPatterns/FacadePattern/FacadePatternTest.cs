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
            // arrange
            var bankAccountFacade = new BankAccountFacade(1234567890, 12345);

            // act
            bankAccountFacade.WithdrawCash(50.00);
            
            // assert
            Assert.Equal(50.00, bankAccountFacade.GetAccountBalance());
        }

        [Fact]
        public void BankAccount_Facade_Inavlid_Account_Number_Test()
        {
            // arrange
            var bankAccountFacade = new BankAccountFacade(333333333, 12345);

            void withdrawAmount() => bankAccountFacade.WithdrawCash(150.00);

            // act
            var exception = Assert.Throws<InvalidOperationException>(withdrawAmount);

            // assert
            Assert.Equal("Invalid Operation", exception.Message);
        }

        [Fact]
        public void BankAccount_Facade_Inavlid_Security_Code_Test()
        {
            // arrange
            var bankAccountFacade = new BankAccountFacade(1234567890, 33333);

            void withdrawAmount() => bankAccountFacade.WithdrawCash(150.00);

            // act
            var exception = Assert.Throws<InvalidOperationException>(withdrawAmount);

            // assert
            Assert.Equal("Invalid Operation", exception.Message);
        }

        [Fact]
        public void BankAccount_Facade_Invalid_Funds_Test()
        {
            // arrange
            var bankAccountFacade = new BankAccountFacade(1234567890, 12345);

            void withdrawAmount() => bankAccountFacade.WithdrawCash(150.00);

            // act
            var exception = Assert.Throws<InvalidOperationException>(withdrawAmount);

            // assert
            Assert.Equal("Invalid Operation", exception.Message);
        }


    }
}
