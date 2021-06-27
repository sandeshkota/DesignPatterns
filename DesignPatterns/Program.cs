using System;
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
using DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors;
using DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard;
using DesignPatterns.BehavioralPatterns.MementoPattern;
using DesignPatterns.BehavioralPatterns.StatePattern;


namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Enter any ket to exit........");
            Console.ReadLine();
        }

        #region BEHAVIOR PATTERNS

        public static void StatePattern()
        {
            var account = new Account("1900675342", "BANK000765", 100.00);
            Console.WriteLine($"Intitial Balance: {account.GetAccountBalance()}");
            account.AddMoney(200);
            Console.WriteLine($"Balance: {account.GetAccountBalance()}");
            account.GetMoney(50);
            Console.WriteLine($"Balance: {account.GetAccountBalance()}");
            account.ChangeToWithheldState();
            account.AddMoney(500);
            Console.WriteLine($"Balance: {account.GetAccountBalance()}");
            account.GetMoney(50);
            Console.WriteLine($"Balance: {account.GetAccountBalance()}");
            try
            {
                account.GetMoney(250);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Balance: {account.GetAccountBalance()}");
            }
            account.ChangeToClosedState();
            try
            {
                account.AddMoney(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Balance: {account.GetAccountBalance()}");
            }
            try
            {
                account.GetMoney(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Balance: {account.GetAccountBalance()}");
            }
        }

        public static void MementoPattern()
        {
            var originator = new Originator();
            var careTaker = new CareTaker();

            var photograph = new Photograph();
            photograph.BrightnessLevel += 20;
            photograph.AddFilter("VIVID");
            originator.SetPhotograph(photograph);

            originator.SaveToMemento(photograph);

            photograph.AddFilter("NATURE");
            var memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            photograph.AddFilter("SNOWFALL");
            photograph.AddFilter("AUTUMN");
            memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            photograph.BrightnessLevel -= 3;
            memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            var firstBackup = careTaker.GetMemento(0);
            var firstPhotograph = firstBackup.GetSavedPhotograph();
            Console.WriteLine($"[1] Photograph Details: Brightness = {firstPhotograph.BrightnessLevel}  |  Filters = { string.Join(" , ", firstPhotograph.GetFilters()) } ");

            var secondBackup = careTaker.GetMemento(1);
            var secondPhotograph = secondBackup.GetSavedPhotograph();
            Console.WriteLine($"[2] Photograph Details: Brightness = {secondPhotograph.BrightnessLevel}  |  Filters = { string.Join(" , ", secondPhotograph.GetFilters()) } ");

            var thirdBackup = careTaker.GetMemento(2);
            var thirdPhotograph = thirdBackup.GetSavedPhotograph();
            Console.WriteLine($"[2] Photograph Details: Brightness = {thirdPhotograph.BrightnessLevel}  |  Filters = { string.Join(" , ", thirdPhotograph.GetFilters()) } ");
        }

        public static void VisitorPattern()
        {
            var totalPoints = 0;

            var gasOfferVisitor = new GasOfferVisitor();
            var hotelOfferVisitor = new HotelOfferVisitor();

            ICreditCard bronzeCreditCard = new BronzeCreditCard();
            ICreditCard silverCreditCard = new SilverCreditCard();
            ICreditCard goldCreditCard = new GoldCreditCard();

            totalPoints += bronzeCreditCard.Accept(gasOfferVisitor);
            totalPoints += bronzeCreditCard.Accept(hotelOfferVisitor);
            Console.WriteLine($"Bronze Credit Card: (Used for Gas & Hotel) Total Points = {totalPoints}");


            totalPoints = 0;
            totalPoints += silverCreditCard.Accept(gasOfferVisitor);
            Console.WriteLine($"Gold Credit Card: (Used for Gas) Total Points = {totalPoints}");

            totalPoints = 0;
            totalPoints += goldCreditCard.Accept(gasOfferVisitor);
            Console.WriteLine($"Gold Credit Card: (Used for Gas) Total Points = {totalPoints}");
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
            while (addressIterator.HasAddress())
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
        #endregion

    }
}
