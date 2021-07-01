using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern.Builders
{
    public class PlatinumGiftCardBuilder: IGiftCardBuilder
    {
        private double _amount;
        public PlatinumGiftCardBuilder(double amount)
        {
            this._amount = amount;
        }

        public GiftCard BuildGiftCard()
        {
            var giftCard = new GiftCard();
            giftCard.SetExpiryDate(DateTime.Today.AddYears(5));
            giftCard.SetCardType("Platinum Gift Card");
            giftCard.SetAmount(this._amount);
            giftCard.SetMembershipBonusMultiplier(1.2);
            return giftCard;
        }
    }
}
