using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.ProxyPattern
{
    public interface IFileParser
    {
        int GetNumberOfLines();
        int GetNumberOfWords();
    }
}
