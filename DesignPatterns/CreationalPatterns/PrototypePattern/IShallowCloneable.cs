using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.PrototypePattern
{
    interface IShallowCloneable<out T>
    {
        T ShallowClone();
    }
}
