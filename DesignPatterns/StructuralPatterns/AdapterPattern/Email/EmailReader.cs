using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdapterPattern.Email
{
    public class EmailReader : IEmailReader
    {
        public string GetSubject()
        {
            return "[Email Subject]";
        }
        public string GetBody()
        {
            return "[Email Body]";
        }
    }
}
