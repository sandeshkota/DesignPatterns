using DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors
{
    public class HotelOfferVisitor : IOfferVisitor
    {
        public int Visit(BronzeCreditCard bronzeCreditCard)
        {
            Console.WriteLine($"Hotel Offer: {bronzeCreditCard.GetName()}");
            return 10;
        }

        public int Visit(SilverCreditCard silverCreditCard)
        {
            Console.WriteLine($"Hotel Offer: {silverCreditCard.GetName()}");
            return 15;
        }

        public int Visit(GoldCreditCard goldCreditCard)
        {
            Console.WriteLine($"Hotel Offer: {goldCreditCard.GetName()}");
            return 20;
        }
    }
}
