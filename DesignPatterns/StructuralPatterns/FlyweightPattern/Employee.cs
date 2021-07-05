using DesignPatterns.StructuralPatterns.FlyweightPattern.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FlyweightPattern
{
    public class Employee
    {
        public readonly string _companyCode;
        public readonly string _companyName;
        public Employee(string companyCode)
        {
            this._companyCode = companyCode;
            this._companyName = CompanyService.GetCompanyName(companyCode);
        }


        private string _name;
        public void SetName(string name)
        {
            this._name = name;
        }

        public string GetDetails()
        {
            return $"{this._name}, {this._companyName} - {this._companyCode}";
        }
    }
}
