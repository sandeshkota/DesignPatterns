using System;
using Xunit;
using DesignPatterns.BehavioralPatterns.IteratorPattern;

namespace DesignPatternTests.BehavioralPatterns.IteratorPattern
{
    [Trait("Pattern", "Behavioral")]
    public class IteratorPatternTest
    {
        [Fact]
        public void Customer_Iterator_Test()
        {
            // arrange
            var totalExpectedAddresses = 3;
            var totalAddressesFromIterator = 0;
            var customer = new Customer { Name = "Sandesh" };
            customer.Address.Add("#01, First Street, Mysuru, Karnataka, India, 570001, 99889988");
            customer.Address.Add("#02, Second Street, Bengaluru, Karnataka, India, 560001, 77667766");
            customer.Address.Add("#03, Third Street, Mandya, Karnataka, India, 550003, 55445544");

            // act
            var addressIterator = customer.GetAddressIterator();
            while (addressIterator.HasAddress())
            {
                var address = addressIterator.GetAddress();

                if(address != null)
                {
                    totalAddressesFromIterator++;
                }
                addressIterator.MoveToNextAddress();
            }

            // assert
            Assert.Equal(totalExpectedAddresses, totalAddressesFromIterator);
        }

        [Fact]
        public void Customer_Iterator_Null_Test()
        {
            // arrange
            var customer = new Customer { Name = "Sandesh" };
            customer.Address.Add("#01, First Street, Mysuru, Karnataka, India, 570001, 99889988");
            customer.Address.Add("#02, Second Street, Bengaluru, Karnataka, India, 560001, 77667766");

            // act
            var addressIterator = customer.GetAddressIterator();
            while (addressIterator.HasAddress())
            {
                var address = addressIterator.GetAddress();
                addressIterator.MoveToNextAddress();
            }

            // assert
            Assert.Null(addressIterator.GetAddress());
        }

        [Fact]
        public void Employee_Iterator_Test()
        {
            // arrange
            var totalExpectedAddresses = 2;
            var totalAddressesFromIterator = 0;
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

            // act
            var addressIterator = employee.GetAddressIterator();
            while (addressIterator.HasAddress())
            {
                var address = addressIterator.GetAddress();

                if (address != null)
                {
                    totalAddressesFromIterator++;
                }

                addressIterator.MoveToNextAddress();
            }

            // assert
            Assert.Equal(totalExpectedAddresses, totalAddressesFromIterator);
        }

        [Fact]
        public void Employee_Iterator_Null_Test()
        {
            // arrange
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

            // act
            var addressIterator = employee.GetAddressIterator();
            while (addressIterator.HasAddress())
            {
                var address = addressIterator.GetAddress();
                addressIterator.MoveToNextAddress();
            }

            // assert
            Assert.Null(addressIterator.GetAddress());
        }
    }
}
