using Xunit;
using System;
using DesignPatterns.StructuralPatterns.AdapterPattern;
using DesignPatterns.StructuralPatterns.AdapterPattern.Email;
using DesignPatterns.StructuralPatterns.AdapterPattern.TextFile;
using DesignPatterns.StructuralPatterns.AdapterPattern.EmailAdapter;

namespace DesignPatternTests.StructuralPatterns.AdapterPattern
{
    [Trait("Pattern", "Structural")]
    public class AdapterPatternTest
    {
        [Fact]
        public void Text_Reader_Data_Formatter_Test()
        {
            // arrange
            ITextReader textReader = new TextReader();
            var textDataFormatter = new DataFormatter(textReader);

            // act
            var textData = textDataFormatter.GetData();
            
            // assert
            Assert.Equal("[File Name] ==> [File Content]", textData, true);
        }

        [Fact]
        public void Email_Reader_Data_Formatter_Test()
        {
            // arrange
            IEmailReader emailReader = new EmailReader();
            ITextReader emailReaderAdapter = new EmailReaderAdapter(emailReader);
            var emailDataFormatter = new DataFormatter(emailReaderAdapter);

            // act
            var emailData = emailDataFormatter.GetData();

            // assert
            Assert.Equal("[Email Subject] ==> [Email Body]", emailData, true);
        }
    }
}
