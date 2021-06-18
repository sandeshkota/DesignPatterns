using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class ChiefFinancialOfficer : IReimburser
    {
        private IReimburser _successor;
        private const double REIMBURSE_LIMIT = 1000.00;
        public bool HasReimbursed = false;

        public void Reimburse(double amount)
        {
            if (amount <= REIMBURSE_LIMIT)
            {
                Console.WriteLine($"Amount {amount} has been reimbursed by CFO.");
                this.HasReimbursed = true;
            }
            else
            {
                Console.WriteLine($"Amount {amount} cannot be reimbursed through portal.");
            }
        }

        public void SetNextReimburser(IReimburser reimburser)
        {
            _successor = reimburser;
        }
    }
}
