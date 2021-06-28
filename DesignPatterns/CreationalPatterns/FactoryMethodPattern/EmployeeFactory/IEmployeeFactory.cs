using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeFactory
{
    public interface IEmployeeFactory
    {
        Employee GetEmployee();
    }
}
