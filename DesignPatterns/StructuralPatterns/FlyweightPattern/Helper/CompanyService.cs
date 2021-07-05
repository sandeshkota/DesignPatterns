using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FlyweightPattern.Helper
{
    public static class CompanyService
    {
        private static Dictionary<string, string> companyData = new();

        static CompanyService()
        {
            companyData.Add("COM0123", "My Company");
            companyData.Add("COM0234", "My New Company");
        }

        public static string GetCompanyName(string companyCode)
        {
            return companyData[companyCode];
        }

    }
}
