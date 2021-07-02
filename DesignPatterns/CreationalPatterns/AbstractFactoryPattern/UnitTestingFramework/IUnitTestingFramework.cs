using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTest;
using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingLibrary;

namespace DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingFramework
{
    public interface IUnitTestingFramework
    {
        IUnitTest GetUnitTest();
        IUnitTestingLibrary GetUnitTestingLibrary();
    }
}
