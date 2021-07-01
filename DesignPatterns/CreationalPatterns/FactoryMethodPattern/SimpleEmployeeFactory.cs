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
            BaseEmployeeService employeeService = null;
            
            switch (employeeType)
            {
                case EmployeeType.PermanentEmployee:
                    employeeService = new PermanentEmployeeService();
                    break;
                case EmployeeType.ContractEmployee:
                    employeeService = new ContractEmployeeService();
                    break;
            }

            return employeeService;
        }
    }
}
