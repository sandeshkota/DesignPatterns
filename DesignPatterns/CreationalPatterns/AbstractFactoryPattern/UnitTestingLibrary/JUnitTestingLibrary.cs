using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingLibrary
{
    public class JUnitTestingLibrary : IUnitTestingLibrary
    {
        public string GetName()
        {
            return "JUnitTestingLibrary";
        }
    }
}
