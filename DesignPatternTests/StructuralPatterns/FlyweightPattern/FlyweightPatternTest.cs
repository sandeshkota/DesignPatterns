using Xunit;
using DesignPatterns.StructuralPatterns.FlyweightPattern;

namespace DesignPatternTests.StructuralPatterns.FlyweightPattern
{
    [Trait("Pattern", "Structural")]
    public class FlyweightPatternTest
    {
        [Fact]
        public void Single_Employee_Test()
        {
            var companyCode = "COM0123";
            var employeeFactory = new EmployeeFactory();

            var employee = employeeFactory.GetEmployee(companyCode);
            employee.SetName("Sandesh");
            var employeeDetails = employee.GetDetails();

            Assert.Equal("Sandesh, My Company - COM0123", employeeDetails);
        }

        [Fact]
        public void Two_Employees_Test()
        {
            var companyCode = "COM0123";
            var employeeFactory = new EmployeeFactory();

            var employee = employeeFactory.GetEmployee(companyCode);
            employee.SetName("Sandesh");
            var employeeDetails = employee.GetDetails();
            
            Assert.Equal("Sandesh, My Company - COM0123", employeeDetails);

            var newEmployee = employeeFactory.GetEmployee(companyCode);
            newEmployee.SetName("Kota");
            var newEmployeeDetails = newEmployee.GetDetails();

            Assert.Equal("Kota, My Company - COM0123", newEmployeeDetails);
        }

        [Fact]
        public void Multiple_Company_Employees_Test()
        {
            var myCompanyCode = "COM0123";
            var myNewCompanyCode = "COM0234";
            var employeeFactory = new EmployeeFactory();

            var employee = employeeFactory.GetEmployee(myCompanyCode);
            employee.SetName("Sandesh");
            var employeeDetails = employee.GetDetails();

            Assert.Equal("Sandesh, My Company - COM0123", employeeDetails);

            var newEmployee = employeeFactory.GetEmployee(myNewCompanyCode);
            newEmployee.SetName("Kota");
            var newEmployeeDetails = newEmployee.GetDetails();

            Assert.Equal("Kota, My New Company - COM0234", newEmployeeDetails);
        }
    }
}
