using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern
{
    public class SimpleEmployeeFactory
    {
        public BaseEmployeeService GetEmployeeService(EmployeeType employeeType)
        {
            switch (employeeType)
            {
                case EmployeeType.PermanentEmployee:
                    return new PermanentEmployeeService();
                case EmployeeType.ContractEmployee:
                    return new ContractEmployeeService();
                default:
                    return null;
            }
        }
    }
}
