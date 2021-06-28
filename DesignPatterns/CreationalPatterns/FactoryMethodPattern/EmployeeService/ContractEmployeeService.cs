using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService
{
    public class ContractEmployeeService : BaseEmployeeService
    {
        public override EmployeeType GetEmployeeType()
        {
            return EmployeeType.ContractEmployee;
        }

        public override double GetHourlyPrice()
        {
            return 80;
        }

        public double GetFoodAllowance()
        {
            return 100;
        }
    }
}
