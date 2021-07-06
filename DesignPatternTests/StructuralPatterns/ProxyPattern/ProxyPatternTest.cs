using Xunit;
using DesignPatterns.StructuralPatterns.ProxyPattern;

namespace DesignPatternTests.StructuralPatterns.ProxyPattern
{
    [Trait("Pattern", "Structural")]
    public class ProxyPatternTest
    {
        [Fact]
        public void Lazy_File_Parser_Proxy_Lines_Test()
        {
            // arrange
            var lazyFileParserProxy = new LazyFileParserProxy("d:/temp/big_file.txt");

            // act
            var numberOfLines = lazyFileParserProxy.GetNumberOfLines();

            // assert
            Assert.Equal(10000, numberOfLines);
        }

        [Fact]
        public void Lazy_File_Parser_Proxy_Words_Test()
        {
            // arrange
            var lazyFileParserProxy = new LazyFileParserProxy("d:/temp/big_file.txt");

            // act
            var numberOfWords = lazyFileParserProxy.GetNumberOfWords();

            // assert
            Assert.Equal(500000, numberOfWords);
        }
    }
}
