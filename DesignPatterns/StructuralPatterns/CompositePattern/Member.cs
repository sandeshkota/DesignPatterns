using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.CompositePattern
{
    public class Member: IEmployee
    {
        private readonly string _name;
        public Member(string name)
        {
            this._name = name;
        }

        public string GetDetails()
        {
            return this._name;
        }
    }
}
