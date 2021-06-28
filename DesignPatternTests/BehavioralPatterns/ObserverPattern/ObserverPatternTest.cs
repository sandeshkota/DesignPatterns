using Xunit;
using DesignPatterns.BehavioralPatterns.ObserverPattern;
using DesignPatterns.BehavioralPatterns.ObserverPattern.Observers;

namespace DesignPatternTests.BehavioralPatterns.ObserverPattern
{
    [Trait("Pattern", "Behavioral")]
    public class ObserverPatternTest
    {
        [Fact]
        public void Exception_Two_Observer_Test()
        {
            // arrange
            var exceptionHandler = new ExceptionHandler();
            var emailLogger = new EmailLogger();
            var tableLogger = new TableLogger();
            exceptionHandler.RegisterObserver(emailLogger);
            exceptionHandler.RegisterObserver(tableLogger);

            // act
            exceptionHandler.HandleException("Invalid Object Cast");

            // assert
            Assert.True(emailLogger.IsEmailSent);
            Assert.True(tableLogger.IsSavedToDB);
        }

        [Fact]
        public void Exception_Single_Observer_Test()
        {
            // arrange
            var exceptionHandler = new ExceptionHandler();
            var emailLogger = new EmailLogger();
            var tableLogger = new TableLogger();
            exceptionHandler.RegisterObserver(emailLogger);

            // act
            exceptionHandler.HandleException("Invalid Object Cast");

            // assert
            Assert.True(emailLogger.IsEmailSent);
            Assert.False(tableLogger.IsSavedToDB);
        }

        [Fact]
        public void Exception_No_Observer_Test()
        {
            // arrange
            var exceptionHandler = new ExceptionHandler();
            var emailLogger = new EmailLogger();
            var tableLogger = new TableLogger();

            // act
            exceptionHandler.HandleException("Invalid Object Cast");

            // assert
            Assert.False(emailLogger.IsEmailSent);
            Assert.False(tableLogger.IsSavedToDB);
        }

        [Fact]
        public void Exception_UnRegister_Test()
        {
            // arrange
            var exceptionHandler = new ExceptionHandler();
            var emailLogger = new EmailLogger();
            var tableLogger = new TableLogger();
            exceptionHandler.RegisterObserver(emailLogger);
            exceptionHandler.RegisterObserver(tableLogger);
            exceptionHandler.UnRegisterObserver(tableLogger);

            // act
            exceptionHandler.HandleException("Invalid Object Cast");

            // assert
            Assert.True(emailLogger.IsEmailSent);
            Assert.False(tableLogger.IsSavedToDB);
        }

        [Fact]
        public void Exception_All_UnRegister_Test()
        {
            // arrange
            var exceptionHandler = new ExceptionHandler();
            var emailLogger = new EmailLogger();
            var tableLogger = new TableLogger();
            exceptionHandler.RegisterObserver(emailLogger);
            exceptionHandler.RegisterObserver(tableLogger);
            exceptionHandler.UnRegisterObserver(emailLogger);
            exceptionHandler.UnRegisterObserver(tableLogger);

            // act
            exceptionHandler.HandleException("Invalid Object Cast");

            // assert
            Assert.False(emailLogger.IsEmailSent);
            Assert.False(tableLogger.IsSavedToDB);
        }

    }
}
