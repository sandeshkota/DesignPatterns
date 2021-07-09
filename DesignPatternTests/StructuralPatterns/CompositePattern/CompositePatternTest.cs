using Xunit;
using DesignPatterns.StructuralPatterns.CompositePattern;
using System.Collections.Generic;

namespace DesignPatternTests.StructuralPatterns.CompositePattern
{
    [Trait("Pattern", "Structural")]
    public class CompositePatternTest
    {
        [Fact]
        public void Composite_Pattern_Test()
        {
            var sandesh = new Member("Sandesh");
            var kota = new Member("Kota");
            var ashwin = new Member("Ashwin");
            var kohli = new Member("Kohli");

            var raina = new Manager("Raina", new List<IEmployee> { sandesh, kota });
            var devdut = new Manager("Devdut", new List<IEmployee> { ashwin, raina });
            var rahul = new Manager("Rahul", new List<IEmployee> { devdut, kohli });

            Assert.Equal("<ul>Rahul<li><ul>Devdut<li>Ashwin</li><li><ul>Raina<li>Sandesh</li><li>Kota</li></ul></li></ul></li><li>Kohli</li></ul>", rahul.GetDetails());
        }
    }
}
