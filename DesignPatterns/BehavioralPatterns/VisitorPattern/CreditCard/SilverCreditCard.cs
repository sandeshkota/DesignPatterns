using DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard
{
    public class SilverCreditCard : ICreditCard
    {
        private const string CARD_NAME = "SILVER Credit Card";
        public string GetName()
        {
            return CARD_NAME;
        }

        public int Accept(IOfferVisitor offerVisitor)
        {
            return offerVisitor.Visit(this);
        }
    }
}
