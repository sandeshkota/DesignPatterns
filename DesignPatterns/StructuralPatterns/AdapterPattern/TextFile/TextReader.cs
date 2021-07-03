using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdapterPattern.TextFile
{
    public class TextReader : ITextReader
    {
        public string GetTitle()
        {
            return "[File Name]";
        }
        public string GetContent()
        {
            return "[File Content]";
        }
    }
}
