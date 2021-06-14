﻿using DesignPatterns.BehavioralPatterns.MediatorPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {






            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter any ket to exit........");
            Console.ReadLine();
        }


        public static void MediatorPattern()
        {
            var amar = new Visitor("Amar");
            var akbar = new Visitor("Akbar");
            var anthony = new Visitor("Anthony");

            var chatRoom = new ChatRoom();
            amar.Enter(chatRoom);
            akbar.Enter(chatRoom);
            anthony.Enter(chatRoom);

            amar.Send("Hello Everyone");
            akbar.Send("Hello Amar!!");
            anthony.Send("Welcome to the chat room Amar :)");
        }

        public static void StrategyPattern()
        {
            var customerService = new CustomerService();
            customerService.SetRatingStrategy(new MoodyRatingStrategy());
            customerService.SetInterestStrategy(new HighInterestRateStrategy());
            customerService.SetDiscountStrategy(new DefaultDiscountStrategy());

            var customerInterestRate = customerService.GetInterestRate(123, "Home");

            Console.WriteLine($"The interest rate for customer is {customerInterestRate}");
        }

    }
}
