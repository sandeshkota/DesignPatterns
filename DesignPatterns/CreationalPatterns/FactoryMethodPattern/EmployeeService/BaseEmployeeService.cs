using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService
{
    public abstract class BaseEmployeeService
    {
        public abstract EmployeeType GetEmployeeType();

        public abstract double GetHourlyPrice();

    }
}
