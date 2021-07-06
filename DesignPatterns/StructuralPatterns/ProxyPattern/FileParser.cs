using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.ProxyPattern
{
    public class FileParser: IFileParser
    {
        private readonly FileInfo fileInfo;
        public FileParser(string filePath)
        {
            // consider that we use the path and load the file - this is a costly operation
            this.fileInfo = new FileInfo
            {
                FilePath = filePath,
                NumberOfLines = 10000,
                NumberOfWords = 500000
            };
        }

        public int GetNumberOfLines()
        {
            return this.fileInfo.NumberOfLines;
        }

        public int GetNumberOfWords()
        {
            return this.fileInfo.NumberOfWords;
        }

    }
}
