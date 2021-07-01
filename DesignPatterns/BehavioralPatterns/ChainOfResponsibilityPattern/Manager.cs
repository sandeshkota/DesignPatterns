using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class Manager : IReimburser
    {
        private IReimburser _successor;
        private const double REIMBURSE_LIMIT = 500.00;
        public bool HasReimbursed { get; private set; } = false;

        public void Reimburse(double amount)
        {
            if (amount <= REIMBURSE_LIMIT)
            {
                Console.WriteLine($"Amount {amount} has been reimbursed by Manager.");
                this.HasReimbursed = true;
            }
            else
            {
                Console.WriteLine($"Manager cannot reimburse amount greater than 500");
                _successor.Reimburse(amount);
            }
        }
        public void SetNextReimburser(IReimburser reimburser)
        {
            _successor = reimburser;
        }
    }
}
