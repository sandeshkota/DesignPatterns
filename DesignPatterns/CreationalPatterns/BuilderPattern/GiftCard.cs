using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    public class GiftCard
    {
        public string CardType { get; private set; }
        public string CardNumber { get; private set; }
        public int CVV { get; private set; }
        public DateTime ExpirtyDate { get; private set; }
        public double MembershipBonusMultiplier { get; private set; } = 1;

        private double _amount;
        public double Amount
        {
            get
            {
                return this._amount * this.MembershipBonusMultiplier;
            }
            private set { this._amount = value; }
        }


        public GiftCard()
        {
            this.CardNumber = Helper.GetRandomString(10);
            this.CVV = Helper.GetRandomNumberCVV();
        }

        public void SetCardType(string cardType)
        {
            this.CardType = cardType;
        }

        public void SetExpiryDate(DateTime expiryDate)
        {
            this.ExpirtyDate = expiryDate;
        }

        public void SetAmount(double amount)
        {
            this.Amount = amount;
        }

        public void SetMembershipBonusMultiplier(double membershipBonusMultiplier)
        {
            this.MembershipBonusMultiplier = membershipBonusMultiplier;
        }

    }


    internal class Helper
    {
        internal static string GetRandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        internal static int GetRandomNumberCVV()
        {
            var random = new Random();
            return random.Next(100, 999);
        }
    }
}
