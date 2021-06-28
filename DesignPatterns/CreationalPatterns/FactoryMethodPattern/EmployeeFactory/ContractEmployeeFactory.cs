using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeFactory
{
    public class ContractEmployeeFactory : IEmployeeFactory
    {
        public Employee GetEmployee()
        {
            var employeeService = new ContractEmployeeService();
            var employee = new Employee {
                EmployeeType = employeeService.GetEmployeeType(),
                HourlyPay = employeeService.GetHourlyPrice(),
                FoodAllowance = employeeService.GetFoodAllowance()
            };
            return employee;
        }

    }
}
