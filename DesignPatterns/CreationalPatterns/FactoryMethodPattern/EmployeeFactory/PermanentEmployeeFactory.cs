using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeFactory
{
    public class PermanentEmployeeFactory : IEmployeeFactory
    {
        public Employee GetEmployee()
        {
            var employeeService = new PermanentEmployeeService();
            var employee = new Employee
            {
                EmployeeType = employeeService.GetEmployeeType(),
                HourlyPay = employeeService.GetHourlyPrice(),
                YearlyBonus = employeeService.GetYearlyBonus()
            };
            return employee;
        }
    }
}
