using Xunit;
using DesignPatterns.CreationalPatterns.FactoryMethodPattern;
using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService;
using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeFactory;

namespace DesignPatternTests.CreationalPatterns.FactoryMethodPattern
{
    [Trait("Pattern", "Creational")]
    public class FactoryMethodPatternTest
    {
        [Fact]
        public void Simple_Employee_Permanent_Employee_Test()
        {
            var simpleEmployeeFactory = new SimpleEmployeeFactory();

            var permanentEmployeeService = simpleEmployeeFactory.GetEmployeeService(EmployeeType.PermanentEmployee);

            Assert.Equal(EmployeeType.PermanentEmployee, permanentEmployeeService.GetEmployeeType());
            Assert.Equal(100, permanentEmployeeService.GetHourlyPrice());
        }

        [Fact]
        public void Simple_Employee_Contract_Employee_Test()
        {
            var simpleEmployeeFactory = new SimpleEmployeeFactory();

            var permanentEmployeeService = simpleEmployeeFactory.GetEmployeeService(EmployeeType.ContractEmployee);

            Assert.Equal(EmployeeType.ContractEmployee, permanentEmployeeService.GetEmployeeType());
            Assert.Equal(80, permanentEmployeeService.GetHourlyPrice());
        }

        [Fact]
        public void Permanent_Employee_Factory_Test()
        {
            var employeeFactory = new PermanentEmployeeFactory();

            var employee = employeeFactory.GetEmployee();

            Assert.Equal(EmployeeType.PermanentEmployee, employee.EmployeeType);
            Assert.Equal(100, employee.HourlyPay);
            Assert.Equal(2000, employee.YearlyBonus);
        }

        [Fact]
        public void Contract_Employee_Factory_Test()
        {
            var employeeFactory = new ContractEmployeeFactory();

            var employee = employeeFactory.GetEmployee();

            Assert.Equal(EmployeeType.ContractEmployee, employee.EmployeeType);
            Assert.Equal(80, employee.HourlyPay);
            Assert.Equal(100, employee.FoodAllowance);
        }
    }
}
