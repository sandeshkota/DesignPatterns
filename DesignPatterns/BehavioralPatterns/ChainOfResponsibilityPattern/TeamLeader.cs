using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class TeamLeader : IReimburser
    {
        private IReimburser _successor;
        private const double REIMBURSE_LIMIT = 100.00;
        public bool HasReimbursed { get; private set; } = false;

        public void Reimburse(double amount)
        {
            if(amount <= REIMBURSE_LIMIT)
            {
                Console.WriteLine($"Amount {amount} has been reimbursed by Team Leader.");
                this.HasReimbursed = true;
            }
            else
            {
                Console.WriteLine($"Team Leader cannot reimburse amount greater than 100");
                _successor.Reimburse(amount);
            }
        }

        public void SetNextReimburser(IReimburser reimburser)
        {
            _successor = reimburser;
        }
    }
}
