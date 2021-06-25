using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors;
using DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard;

namespace DesignPatternTests.BehavioralPatterns.VisitorPattern
{
    public class VisitorPatternTest
    {
        [Fact]
        public void Bronze_CreditCard_Test()
        {
            // arrange
            var totalPoints = 0;

            var gasOfferVisitor = new GasOfferVisitor();
            var hotelOfferVisitor = new HotelOfferVisitor();

            ICreditCard bronzeCreditCard = new BronzeCreditCard();

            // act
            totalPoints += bronzeCreditCard.Accept(gasOfferVisitor);
            totalPoints += bronzeCreditCard.Accept(hotelOfferVisitor);
            
            // assert
            Assert.Equal(13, totalPoints);
        }

        [Fact]
        public void Silver_CreditCard_Test()
        {
            // arrange
            var totalPoints = 0;

            var gasOfferVisitor = new GasOfferVisitor();
            var hotelOfferVisitor = new HotelOfferVisitor();
            ICreditCard silverCreditCard = new SilverCreditCard();

            // act
            totalPoints += silverCreditCard.Accept(gasOfferVisitor);
            totalPoints += silverCreditCard.Accept(hotelOfferVisitor);

            // assert
            Assert.Equal(21, totalPoints);
        }

        [Fact]
        public void Gold_CreditCard_Test()
        {
            // arrange
            var totalPoints = 0;

            var gasOfferVisitor = new GasOfferVisitor();
            var hotelOfferVisitor = new HotelOfferVisitor();
            ICreditCard goldCreditCard = new GoldCreditCard();

            // act
            totalPoints += goldCreditCard.Accept(gasOfferVisitor);
            totalPoints += goldCreditCard.Accept(hotelOfferVisitor);

            // assert
            Assert.Equal(30, totalPoints);
        }


        [Fact]
        public void Gas_Offer_Test()
        {
            // arrange
            var totalPoints = 0;

            var gasOfferVisitor = new GasOfferVisitor();

            ICreditCard bronzeCreditCard = new BronzeCreditCard();
            ICreditCard silverCreditCard = new SilverCreditCard();
            ICreditCard goldCreditCard = new GoldCreditCard();

            // act
            totalPoints += bronzeCreditCard.Accept(gasOfferVisitor);
            totalPoints += silverCreditCard.Accept(gasOfferVisitor);
            totalPoints += goldCreditCard.Accept(gasOfferVisitor);

            // assert
            Assert.Equal(19, totalPoints);
        }

        [Fact]
        public void Hotel_Offer_Test()
        {
            // arrange
            var totalPoints = 0;

            var hotelOfferVisitor = new HotelOfferVisitor();

            ICreditCard bronzeCreditCard = new BronzeCreditCard();
            ICreditCard silverCreditCard = new SilverCreditCard();
            ICreditCard goldCreditCard = new GoldCreditCard();

            // act
            totalPoints += bronzeCreditCard.Accept(hotelOfferVisitor);
            totalPoints += silverCreditCard.Accept(hotelOfferVisitor);
            totalPoints += goldCreditCard.Accept(hotelOfferVisitor);

            // assert
            Assert.Equal(45, totalPoints);
        }

        [Fact]
        public void Silver_CreditCard_Hotel_And_Gold_CreditCard_Gas_Offer_Test()
        {
            // arrange
            var totalPoints = 0;
            
            var hotelOfferVisitor = new HotelOfferVisitor();
            var gasOfferVisitor = new GasOfferVisitor();

            ICreditCard silverCreditCard = new SilverCreditCard();
            ICreditCard goldCreditCard = new GoldCreditCard();

            // act
            totalPoints += silverCreditCard.Accept(hotelOfferVisitor);
            totalPoints += goldCreditCard.Accept(gasOfferVisitor);

            // assert
            Assert.Equal(25, totalPoints);
        }
    }
}
