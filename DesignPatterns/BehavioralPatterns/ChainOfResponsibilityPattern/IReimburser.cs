using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public interface IReimburser
    {
        void Reimburse(double amount);
        void SetNextReimburser(IReimburser reimburser);
    }
}
