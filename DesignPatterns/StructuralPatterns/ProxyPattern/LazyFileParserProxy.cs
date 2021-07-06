using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.ProxyPattern
{
    public class LazyFileParserProxy : IFileParser
    {
        private FileParser _parser = null;
        private string _filePath;
        public LazyFileParserProxy(string filePath)
        {
            this._filePath = filePath;
        }

        public int GetNumberOfLines()
        {
            var parser = this.GetFileParser();
            return parser.GetNumberOfLines();
        }

        public int GetNumberOfWords()
        {
            var parser = this.GetFileParser();
            return parser.GetNumberOfWords();
        }

        private FileParser GetFileParser()
        {
            if(this._parser == null)
            {
                this._parser = new FileParser(this._filePath);
            }
            return this._parser;
        }
    }
}
