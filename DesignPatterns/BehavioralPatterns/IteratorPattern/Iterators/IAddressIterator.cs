using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.IteratorPattern.Iterators
{
    public interface IAddressIterator
    {
        bool HasAddress();
        void MoveToNextAddress();
        Address GetAddress();
    }
}
