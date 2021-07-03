using DesignPatterns.StructuralPatterns.AdapterPattern.Email;
using DesignPatterns.StructuralPatterns.AdapterPattern.TextFile;

namespace DesignPatterns.StructuralPatterns.AdapterPattern.EmailAdapter
{
    public class EmailReaderAdapter : ITextReader
    {
        private IEmailReader _emailReader;
        public EmailReaderAdapter(IEmailReader emailReader)
        {
            this._emailReader = emailReader;
        }

        public string GetTitle()
        {
            return this._emailReader.GetSubject();
        }

        public string GetContent()
        {
            return this._emailReader.GetBody();
        }
    }
}
