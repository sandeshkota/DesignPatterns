using System;
using Xunit;
using DesignPatterns.CreationalPatterns.SingletonPattern;

namespace DesignPatternTests.CreationalPatterns.SingletonPattern
{
    [Trait("Pattern", "Creational")]
    public class SingletonPatternTest
    {
        [Fact]
        public void ConfigurationManager_Test()
        {
            // arrange
            var configurationManager = ConfigurationManager.GetInstance();
            configurationManager.Upsert("name", "kota");

            var anotherConfigurationManager = ConfigurationManager.GetInstance();

            // act
            anotherConfigurationManager.Upsert("name", "sandesh");

            // assert
            Assert.Equal("sandesh", configurationManager.GetValue("name"));
            Assert.Equal("sandesh", anotherConfigurationManager.GetValue("name"));
        }

        [Fact]
        public void ConfigurationManager_Null_Test()
        {
            // arrange
            var configurationManager = ConfigurationManager.GetInstance();

            // act
            var name = configurationManager.GetValue("nickname");
            
            // assert
            Assert.Null(name);
        }
    }
}
