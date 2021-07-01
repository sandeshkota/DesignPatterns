using DesignPatterns.CreationalPatterns.BuilderPattern.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    public class GiftCardCreator
    {
        public GiftCard CreateGiftCard(IGiftCardBuilder giftCardbuilder)
        {
            return giftCardbuilder.BuildGiftCard();
        }
    }
}
