using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdapterPattern.TextFile
{
    public interface ITextReader
    {
        string GetTitle();
        string GetContent();
    }
}
