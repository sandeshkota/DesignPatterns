using DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors
{
    public interface IOfferVisitor
    {
        int Visit(BronzeCreditCard bronzeCreditCard);
        int Visit(SilverCreditCard silverCreditCard);
        int Visit(GoldCreditCard goldCreditCard);
    }
}
