using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern
{
    public class Employee
    {
        public EmployeeType EmployeeType{ get; set; }
        public double HourlyPay { get; set; }
        public double YearlyBonus { get; set; }
        public double FoodAllowance { get; set; }
    }
}
