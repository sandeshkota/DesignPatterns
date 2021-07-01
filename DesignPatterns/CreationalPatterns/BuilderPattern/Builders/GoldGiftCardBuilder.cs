using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern.Builders
{
    public class GoldGiftCardBuilder: IGiftCardBuilder
    {
        private readonly double _amount;
        public GoldGiftCardBuilder(double amount)
        {
            this._amount = amount;
        }

        public GiftCard BuildGiftCard()
        {
            var giftCard = new GiftCard();
            giftCard.SetExpiryDate(DateTime.Today.AddYears(3));
            giftCard.SetCardType("Gold Gift Card");
            giftCard.SetAmount(this._amount);
            giftCard.SetMembershipBonusMultiplier(1.05);
            return giftCard;
        }
    }
}
