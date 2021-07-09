using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.CompositePattern
{
    public class Manager : IEmployee
    {
        private readonly string _name;
        private readonly List<IEmployee> _reportees;
        public Manager(string name, List<IEmployee> reportees)
        {
            this._name = name;
            this._reportees = reportees;
        }

        public string GetDetails()
        {
            var details = new StringBuilder();

            details.Append("<ul>");
            details.Append(this._name);

            foreach (var reportee in this._reportees)
            {
                details.Append("<li>");
                details.Append(reportee.GetDetails());
                details.Append("</li>");
            }
            details.Append("</ul>");

            return details.ToString();
        }
    }
}
