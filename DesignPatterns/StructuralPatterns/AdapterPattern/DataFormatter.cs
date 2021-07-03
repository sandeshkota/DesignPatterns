using DesignPatterns.StructuralPatterns.AdapterPattern.TextFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdapterPattern
{
    public class DataFormatter
    {
        private readonly ITextReader _textReader;
        public DataFormatter(ITextReader textReader)
        {
            this._textReader = textReader;
        }

        public string GetData()
        {
            return $"{this._textReader.GetTitle()} ==> {this._textReader.GetContent()}";
        }
    }
}
