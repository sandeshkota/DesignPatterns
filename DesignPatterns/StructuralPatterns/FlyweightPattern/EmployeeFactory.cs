using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FlyweightPattern
{
    public class EmployeeFactory
    {
        private readonly Dictionary<string, Employee> employees = new();
        public Employee GetEmployee(string companyCode)
        {
            if (employees.ContainsKey(companyCode))
            {
                return employees[companyCode];
            }
            else
            {
                var employee = new Employee(companyCode);
                employees.Add(companyCode, employee);
                return employee;
            }
        }
    }
}
