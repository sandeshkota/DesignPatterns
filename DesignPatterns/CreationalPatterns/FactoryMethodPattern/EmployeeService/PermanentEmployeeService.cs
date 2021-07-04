using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService
{
    public class PermanentEmployeeService : BaseEmployeeService
    {
        private const double YEARLY_BONUS = 2000;
        public override EmployeeType GetEmployeeType()
        {
            return EmployeeType.PermanentEmployee;
        }

        public override double GetHourlyPrice()
        {
            return 100;
        }

        public double GetYearlyBonus()
        {
            return YEARLY_BONUS;
        }
    }
}
