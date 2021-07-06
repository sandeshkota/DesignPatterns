using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.ProxyPattern
{
    public class FileInfo
    {
        public int NumberOfLines { get; set; }
        public int NumberOfWords { get; set; }
        public string FilePath { get; set; }
    }
}
