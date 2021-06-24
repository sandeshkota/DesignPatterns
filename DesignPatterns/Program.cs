﻿using System;
using DesignPatterns.BehavioralPatterns.MediatorPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern;
using DesignPatterns.BehavioralPatterns.StrategyPattern.DiscountStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.InterestStrategies;
using DesignPatterns.BehavioralPatterns.StrategyPattern.RatingStrategies;
using DesignPatterns.BehavioralPatterns.TemplateMethodPattern;
using DesignPatterns.BehavioralPatterns.ObserverPattern;
using DesignPatterns.BehavioralPatterns.ObserverPattern.Observers;
using DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern;
using DesignPatterns.BehavioralPatterns.CommandPattern;
using DesignPatterns.BehavioralPatterns.CommandPattern.Commands;
using DesignPatterns.BehavioralPatterns.IteratorPattern;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IteratorPattern();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Enter any ket to exit........");
            Console.ReadLine();
        }

        public static void IteratorPattern()
        {
            var customer = new Customer
            {
                Name = "Sandesh"
            };
            customer.Address.Add("#01, First Street, Mysuru, Karnataka, India, 570001, 99889988");
            customer.Address.Add("#02, Second Street, Bengaluru, Karnataka, India, 560001, 77667766");

            var employee = new Employee
            {
                Name = "Kota",
                BuildingNumber1 = "#101",
                Street1 = "Main Street",
                City1 = "Shilong",
                State1 = "Meghalaya",
                Country1 = "India",
                ZipCode1 = "534009",
                PhoneNumber1 = "11111111",
                BuildingNumber2 = "#202",
                Street2 = "Sub Street",
                City2 = "Jaipur",
                State2 = "Rajasthan",
                Country2 = "India",
                ZipCode2 = "230658",
                PhoneNumber2 = "33333333",
            };


            //var addressIterator = customer.GetAddressIterator();
            var addressIterator = employee.GetAddressIterator();
            while(addressIterator.HasAddress())
            {
                var address = addressIterator.GetAddress();

                Console.WriteLine("----- Address -----");
                Console.WriteLine($"Building: {address.BuildingNumber}");
                Console.WriteLine($"Street: {address.StreetName}");
                Console.WriteLine($"City-ZipCode: {address.City} - {address.ZipCode}");
                Console.WriteLine($"State-Country: {address.State} - {address.Country}");
                Console.WriteLine($"Phone Number: {address.PhoneNumber}");

                addressIterator.MoveToNextAddress();
            }

        }

        public static void CommandPattern()
        {
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand, 
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.IncreaseBrightness();
            photoEditor.IncreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.AddVividFilter();
            photoEditor.RemoveVividFilter();
            photoEditor.AddVividFilter();

            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("UNDO OPERTIONS");
            Console.WriteLine("--------------------------");

            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();
        }

        public static void ChainOfResponsibilityPattern()
        {
            var teamLeader = new TeamLeader();
            var manager = new Manager();
            var cfo = new ChiefFinancialOfficer();
            teamLeader.SetNextReimburser(manager);
            manager.SetNextReimburser(cfo);

            teamLeader.Reimburse(100);
            teamLeader.Reimburse(200);
            teamLeader.Reimburse(900);
        }

        public static void ObserverPattern()
        {
            var exceptionHandler = new ExceptionHandler();
            var emailLogger = new EmailLogger();
            var tableLogger = new TableLogger();

            exceptionHandler.RegisterObserver(emailLogger);
            exceptionHandler.RegisterObserver(tableLogger);

            exceptionHandler.HandleException("Invalid Object Cast");
            exceptionHandler.HandleException("Array has no elements");
            exceptionHandler.HandleException("Object reference not set to an instance");
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

        public static void TemplateMethodPattern()
        {
            var user = new User { Name = "Sandesh" };
            user.Save();

            var product = new Product { Name = "Phone", Price = 100.00 };
            product.Save();
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
