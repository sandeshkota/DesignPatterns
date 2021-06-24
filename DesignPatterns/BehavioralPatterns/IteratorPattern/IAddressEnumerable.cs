using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.BehavioralPatterns.IteratorPattern.Iterators;

namespace DesignPatterns.BehavioralPatterns.IteratorPattern
{
    public interface IAddressEnumerable
    {
        IAddressIterator GetAddressIterator();
    }
}
