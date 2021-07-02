using System;
using Xunit;
using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTest;
using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingLibrary;
using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingFramework;

namespace DesignPatternTests.CreationalPatterns.AbstractFactoryPattern
{
    [Trait("Pattern", "Creational")]
    public class AbstractFactoryPatternTest
    {
        [Fact]
        public void NUnitTestingFramework_Test()
        {
            IUnitTestingFramework nUnitTestingFramework = new NUnitTestingFramework();
            var nUnitTest = nUnitTestingFramework.GetUnitTest();
            var nUnitTestLibrary = nUnitTestingFramework.GetUnitTestingLibrary();

            Assert.Equal("NUnitTest", nUnitTest.GetName());
            Assert.Equal("NUnitTestingLibrary", nUnitTestLibrary.GetName());
        }

        [Fact]
        public void JUnitTestingFramework_Test()
        {
            IUnitTestingFramework nUnitTestingFramework = new JUnitTestingFramework();
            var jUnitTest = nUnitTestingFramework.GetUnitTest();
            var jUnitTestLibrary = nUnitTestingFramework.GetUnitTestingLibrary();

            Assert.Equal("JUnitTest", jUnitTest.GetName());
            Assert.Equal("JUnitTestingLibrary", jUnitTestLibrary.GetName());
        }
    }
}
