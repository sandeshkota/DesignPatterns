using DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard
{
    public interface ICreditCard
    {
        string GetName();
        int Accept(IOfferVisitor offerVisitor);
    }
}
