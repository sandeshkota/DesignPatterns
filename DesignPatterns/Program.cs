using System;
using System.Diagnostics.CodeAnalysis;
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
using DesignPatterns.BehavioralPatterns.IteratorPattern.Iterators;
using DesignPatterns.BehavioralPatterns.VisitorPattern.Visitors;
using DesignPatterns.BehavioralPatterns.VisitorPattern.CreditCard;
using DesignPatterns.BehavioralPatterns.MementoPattern;
using DesignPatterns.BehavioralPatterns.StatePattern;
using DesignPatterns.CreationalPatterns.FactoryMethodPattern;
using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeService;
using DesignPatterns.CreationalPatterns.FactoryMethodPattern.EmployeeFactory;
using DesignPatterns.CreationalPatterns.SingletonPattern;
using Proto = DesignPatterns.CreationalPatterns.PrototypePattern;
using DesignPatterns.CreationalPatterns.BuilderPattern;
using DesignPatterns.CreationalPatterns.BuilderPattern.Builders;
using DesignPatterns.CreationalPatterns.AbstractFactoryPattern.UnitTestingFramework;
using DesignPatterns.StructuralPatterns.AdapterPattern;
using DesignPatterns.StructuralPatterns.AdapterPattern.Email;
using DesignPatterns.StructuralPatterns.AdapterPattern.TextFile;
using DesignPatterns.StructuralPatterns.AdapterPattern.EmailAdapter;
using DesignPatterns.StructuralPatterns.BridgePattern.Display;
using DesignPatterns.StructuralPatterns.BridgePattern.ItemService;
using DesignPatterns.StructuralPatterns.BridgePattern.Product;
using DesignPatterns.StructuralPatterns.FlyweightPattern;

namespace DesignPatterns
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        static void Main(string[] args)
        {
            FlyweightPattern(); 

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Enter any ket to exit........");
            Console.ReadLine();
        }   

        #region STRUCTURAL PATTERN

        public static void FlyweightPattern()
        {
            var companyCode = "COM0123";
            var employeeFactory = new EmployeeFactory();

            var employee = employeeFactory.GetEmployee(companyCode);
            employee.SetName("Sandesh");
            Console.WriteLine(employee.GetDetails());

            var newEmployee = employeeFactory.GetEmployee(companyCode);
            newEmployee.SetName("Kota");
            Console.WriteLine(newEmployee.GetDetails());
        }

        public static void BridgePattern()
        {
            var book = new Book { Name = "Harry Potter", BookPhoto = "hp.jpg", Synopsis = "Fantasy" };
            var artist = new Artist { Name = "JK Rowling", ProfilePhoto = "jkr.jpg", Bio = "From UK" };

            IItemService bookService = new BookItemService(book);
            Display cardDisplay = new CardDisplay(bookService);
            Console.WriteLine("----- Book: Card -----");
            Console.WriteLine(cardDisplay.Show());

            IItemService artistService = new ArtistItemService(artist);
            cardDisplay = new CardDisplay(artistService);
            Console.WriteLine("----- Artist: Card -----");
            Console.WriteLine(cardDisplay.Show());

            Display thumbDisplay = new ThumbNailDisplay(bookService);
            Console.WriteLine("----- Book: Thumbnail -----");
            Console.WriteLine(thumbDisplay.Show());

            thumbDisplay = new ThumbNailDisplay(artistService);
            Console.WriteLine("----- Artist: Thumbnail-----");
            Console.WriteLine(thumbDisplay.Show());
        }

        public static void AdapterPattern()
        {
            ITextReader textReader = new TextReader();
            var textDataFormatter = new DataFormatter(textReader);

            var textData = textDataFormatter.GetData();
            Console.WriteLine(textData);

            IEmailReader emailReader = new EmailReader();
            ITextReader emailReaderAdapter = new EmailReaderAdapter(emailReader);
            var emailDataFormatter = new DataFormatter(emailReaderAdapter);

            var emailData = emailDataFormatter.GetData();
            Console.WriteLine(emailData);
        }

        #endregion

        #region CREATIONAL PATTERNS
        public static void AbstractFactoryPattern()
        {
            IUnitTestingFramework nUnitTestingFramework = new NUnitTestingFramework();
            var nUnitTest = nUnitTestingFramework.GetUnitTest();
            var nUnitTestLibrary = nUnitTestingFramework.GetUnitTestingLibrary();

            Console.WriteLine($"Unit Test: {nUnitTest.GetName()} | Unit Test Library: {nUnitTestLibrary.GetName()}");

            nUnitTestingFramework = new JUnitTestingFramework();
            var jUnitTest = nUnitTestingFramework.GetUnitTest();
            var jUnitTestLibrary = nUnitTestingFramework.GetUnitTestingLibrary();

            Console.WriteLine($"Unit Test: {jUnitTest.GetName()} | Unit Test Library: {jUnitTestLibrary.GetName()}");
        }

        public static void BuilderPattern()
        {
            var giftCardCreator = new GiftCardCreator();
            var normalGiftCardBuilder = new NormalGiftCardBuilder(300);
            var normalGiftCard = giftCardCreator.CreateGiftCard(normalGiftCardBuilder);
            PrintGiftCard(normalGiftCard);

            var goldGiftCardBuilder = new GoldGiftCardBuilder(300);
            var goldGiftCard = giftCardCreator.CreateGiftCard(goldGiftCardBuilder);
            PrintGiftCard(goldGiftCard);

            var platinumGiftCardBuilder = new PlatinumGiftCardBuilder(300);
            var platinumGiftCard = giftCardCreator.CreateGiftCard(platinumGiftCardBuilder);
            PrintGiftCard(platinumGiftCard);
        }
        private static void PrintGiftCard(GiftCard giftCard)
        {
            Console.WriteLine($"----- {giftCard.CardType} -----");
            Console.WriteLine($"Card Number: {giftCard.CardNumber} (CVV : {giftCard.CVV})");
            Console.WriteLine($"CardExpiry Date: {giftCard.ExpirtyDate.ToShortDateString()}");
            Console.WriteLine($"Total Balance: {giftCard.Amount}");
            Console.WriteLine();
        }

        public static void PrototypePattern()
        {
            var user = new Proto.User();
            user.Name = "Kota";
            user.PhoneNumber = "99887766";
            user.ResidentialAddress = new Proto.Address
            {
                HouseNumber = "333",
                Street = "Main Street",
                City = "Bengaluru",
                Contact = new Proto.Contact { CountryCode = "91", Number = "98765432" }
            };

            user.CopyResidentialAddressToCommunicationAddress();

            Console.WriteLine("----- Shallow Cloned -----");
            Console.WriteLine($"Residential Address: {user.ResidentialAddress.HouseNumber}, {user.ResidentialAddress.Street}, {user.ResidentialAddress.City}," +
                                $"Contact: {user.ResidentialAddress.Contact.CountryCode} {user.ResidentialAddress.Contact.Number}");
            Console.WriteLine($"Communication Address: {user.CommunicationAddress.HouseNumber}, {user.CommunicationAddress.Street}, {user.CommunicationAddress.City}," +
                                $"Contact: {user.CommunicationAddress.Contact.CountryCode} {user.CommunicationAddress.Contact.Number}");

            Console.WriteLine("----- Changing original Object -----");
            user.ResidentialAddress.HouseNumber = "4444";
            user.ResidentialAddress.Contact.CountryCode = "03";
            Console.WriteLine($"Residential Address: {user.ResidentialAddress.HouseNumber}, {user.ResidentialAddress.Street}, {user.ResidentialAddress.City}," +
                                $"Contact: {user.ResidentialAddress.Contact.CountryCode} {user.ResidentialAddress.Contact.Number}");
            Console.WriteLine($"Communication Address: {user.CommunicationAddress.HouseNumber}, {user.CommunicationAddress.Street}, {user.CommunicationAddress.City}," +
                                $"Contact: {user.CommunicationAddress.Contact.CountryCode} {user.CommunicationAddress.Contact.Number}");


            user.CopyCompleteResidentialAddressToCommunicationAddress();
            
            Console.WriteLine("----- Deep Cloned -----");
            Console.WriteLine("----- Changing original Object -----");
            user.ResidentialAddress.Contact.CountryCode = "57";
            Console.WriteLine($"Residential Address: {user.ResidentialAddress.HouseNumber}, {user.ResidentialAddress.Street}, {user.ResidentialAddress.City}," +
                                $"Contact: {user.ResidentialAddress.Contact.CountryCode} {user.ResidentialAddress.Contact.Number}");
            Console.WriteLine($"Communication Address: {user.CommunicationAddress.HouseNumber}, {user.CommunicationAddress.Street}, {user.CommunicationAddress.City}," +
                                $"Contact: {user.CommunicationAddress.Contact.CountryCode} {user.CommunicationAddress.Contact.Number}");
        }

        public static void SingletonPattern()
        {
            var configurationManager = ConfigurationManager.GetInstance();
            Console.WriteLine(configurationManager.GetValue("database"));
            configurationManager.Upsert("name", "kota");
            Console.WriteLine(configurationManager.GetValue("name"));

            var anotherConfigurationManager = ConfigurationManager.GetInstance();
            Console.WriteLine(anotherConfigurationManager.GetValue("name"));

            anotherConfigurationManager.Upsert("name", "sandesh");
            Console.WriteLine(anotherConfigurationManager.GetValue("name"));
            Console.WriteLine(configurationManager.GetValue("name"));
        }

        public static void FactoryMethodPattern()
        {
            var simpleEmployeeFactory = new SimpleEmployeeFactory();
            Console.WriteLine("----- SIMPLE FACTORY -----");
            var permanentEmployeeService = simpleEmployeeFactory.GetEmployeeService(EmployeeType.PermanentEmployee);
            PrintEmployee(permanentEmployeeService);
            var contractEmployeeService = simpleEmployeeFactory.GetEmployeeService(EmployeeType.ContractEmployee);
            PrintEmployee(contractEmployeeService);

            Console.WriteLine();
            Console.WriteLine("----- FACTORY METHOD -----");
            var permanentEmployeeFactory = new PermanentEmployeeFactory();
            var permanentEmployee = permanentEmployeeFactory.GetEmployee();
            Console.WriteLine($"Employee Type: {permanentEmployee.EmployeeType} " +
                                $"| Price/Hour: {permanentEmployee.HourlyPay} " +
                                $"| Yearly Bonus: {permanentEmployee.YearlyBonus} "
                                );

            var contractEmployeeFactory = new ContractEmployeeFactory();
            var contractEmployee = contractEmployeeFactory.GetEmployee();
            Console.WriteLine($"Employee Type: {contractEmployee.EmployeeType} " +
                                $"| Price/Hour: {contractEmployee.HourlyPay} " +
                                $"| Food Allowance: {contractEmployee.FoodAllowance} "
                                );
        }
        private static void PrintEmployee(BaseEmployeeService firstEmployee)
        {
            Console.WriteLine($"Employee Type: {firstEmployee.GetEmployeeType()} " +
                                $"| Price/Hour: {firstEmployee.GetHourlyPrice()} ");
        }

        #endregion

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

            var employee = new BehavioralPatterns.IteratorPattern.Employee
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

            var addressIterator = employee.GetAddressIterator();
            PrintAddresses("EMPLOYEE", addressIterator);

            Console.WriteLine();

            addressIterator = customer.GetAddressIterator();
            PrintAddresses("CUSTOMER", addressIterator);
        }

        private static void PrintAddresses(string objectType, IAddressIterator addressIterator)
        {
            Console.WriteLine("----- ----- -----");
            Console.WriteLine($"{objectType} ADRESSES");
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

            var profile = new Profile();
            profile.Save();
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
