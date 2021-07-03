using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdapterPattern.Email
{
    public interface IEmailReader
    {
        string GetSubject();
        string GetBody();
    }
}
