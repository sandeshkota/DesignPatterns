using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTest;
using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingFramework
{
    public class NUnitTestingFramework : IUnitTestingFramework
    {
        public IUnitTest GetUnitTest()
        {
            return new NUnitTest();
        }

        public IUnitTestingLibrary GetUnitTestingLibrary()
        {
            return new NUnitTestingLibrary();
        }
    }
}
