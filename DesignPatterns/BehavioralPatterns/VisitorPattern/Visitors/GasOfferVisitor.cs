using DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors
{
    public class GasOfferVisitor : IOfferVisitor
    {
        public int Visit(BronzeCreditCard bronzeCreditCard)
        {
            Console.WriteLine($"Gas Offer: {bronzeCreditCard.GetName()}");
            return 3;
        }

        public int Visit(SilverCreditCard silverCreditCard)
        {
            Console.WriteLine($"Gas Offer: {silverCreditCard.GetName()}");
            return 6;
        }

        public int Visit(GoldCreditCard goldCreditCard)
        {
            Console.WriteLine($"Gas Offer: {goldCreditCard.GetName()}");
            return 10;
        }
    }
}
