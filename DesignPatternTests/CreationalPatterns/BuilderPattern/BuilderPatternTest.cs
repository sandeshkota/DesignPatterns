﻿using System;
using Xunit;
using DesignPatterns.CreationalPatterns.BuilderPattern;
using DesignPatterns.CreationalPatterns.BuilderPattern.Builders;

namespace DesignPatternTests.CreationalPatterns.BuilderPattern
{
    [Trait("Pattern", "Creational")]
    public class BuilderPatternTest
    {
        [Fact]
        public void Normal_Gift_Card_Builder_Test()
        {
            // arrange
            var giftCardCreator = new GiftCardCreator();
            var normalGiftCardBuilder = new NormalGiftCardBuilder(300);

            // act
            var normalGiftCard = giftCardCreator.CreateGiftCard(normalGiftCardBuilder);

            // assert
            Assert.Equal("Gift Card", normalGiftCard.CardType, true);
            Assert.Equal(300, normalGiftCard.Amount);
        }

        [Fact]
        public void Gold_Gift_Card_Builder_Test()
        {
            // arrange
            var giftCardCreator = new GiftCardCreator();
            var goldGiftCardBuilder = new GoldGiftCardBuilder(300);

            // act
            var goldGiftCard = giftCardCreator.CreateGiftCard(goldGiftCardBuilder);

            // assert
            Assert.Equal("Gold Gift Card", goldGiftCard.CardType, true);
            Assert.Equal(315, goldGiftCard.Amount);
        }

        [Fact]
        public void Platinum_Gift_Card_Builder_Test()
        {
            // arrange
            var giftCardCreator = new GiftCardCreator();
            var platinumGiftCardBuilder = new PlatinumGiftCardBuilder(300);

            // act
            var platinumGiftCard = giftCardCreator.CreateGiftCard(platinumGiftCardBuilder);

            // assert
            Assert.Equal("Platinum Gift Card", platinumGiftCard.CardType, true);
            Assert.Equal(360, platinumGiftCard.Amount);
        }
    }
}
