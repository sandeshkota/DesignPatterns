using System;
using Xunit;
using DesignPatterns.CreationalPatterns.PrototypePattern;

namespace DesignPatternTests.CreationalPatterns.PrototypePattern
{
    [Trait("Pattern", "Creational")]
    public class PrototypePatternTest
    {
        [Fact]
        public void User_Address_Shallow_Copy_Test()
        {
            // arrange
            var user = new User();
            user.Name = "Kota";
            user.PhoneNumber = "99887766";
            user.ResidentialAddress = new Address
            {
                HouseNumber = "333",
                Street = "Main Street",
                City = "Bengaluru",
                Contact = new Contact { CountryCode = "91", Number = "98765432" }
            };

            // act
            user.CopyResidentialAddressToCommunicationAddress();

            // assert
            Assert.Equal(user.ResidentialAddress.HouseNumber, user.CommunicationAddress.HouseNumber);
            Assert.Equal(user.ResidentialAddress.Street, user.CommunicationAddress.Street);
            Assert.Equal(user.ResidentialAddress.City, user.CommunicationAddress.City);
            Assert.Equal(user.ResidentialAddress.Contact.CountryCode, user.CommunicationAddress.Contact.CountryCode);
            Assert.Equal(user.ResidentialAddress.Contact.Number, user.CommunicationAddress.Contact.Number);
        }

        [Fact]
        public void User_Address_Shallow_Copy_Change_Test()
        {
            // arrange
            var user = new User();
            user.Name = "Kota";
            user.PhoneNumber = "99887766";
            user.ResidentialAddress = new Address
            {
                HouseNumber = "333",
                Street = "Main Street",
                City = "Bengaluru",
                Contact = new Contact { CountryCode = "91", Number = "98765432" }
            };

            // act
            user.CopyResidentialAddressToCommunicationAddress();
            user.ResidentialAddress.HouseNumber = "4444";
            user.ResidentialAddress.Street = "Sub Street";
            user.ResidentialAddress.City = "Mysuru";
            user.ResidentialAddress.Contact.CountryCode = "03";
            user.ResidentialAddress.Contact.Number = "12345678";
            
            // assert
            Assert.NotEqual(user.ResidentialAddress.HouseNumber, user.CommunicationAddress.HouseNumber);
            Assert.NotEqual(user.ResidentialAddress.Street, user.CommunicationAddress.Street);
            Assert.NotEqual(user.ResidentialAddress.City, user.CommunicationAddress.City);
            Assert.Equal(user.ResidentialAddress.Contact.CountryCode, user.CommunicationAddress.Contact.CountryCode);
            Assert.Equal(user.ResidentialAddress.Contact.Number, user.CommunicationAddress.Contact.Number);
        }

        [Fact]
        public void User_Address_Deep_Copy_Change_Test()
        {
            // arrange
            var user = new User();
            user.Name = "Kota";
            user.PhoneNumber = "99887766";
            user.ResidentialAddress = new Address
            {
                HouseNumber = "333",
                Street = "Main Street",
                City = "Bengaluru",
                Contact = new Contact { CountryCode = "91", Number = "98765432" }
            };

            // act
            user.CopyCompleteResidentialAddressToCommunicationAddress();
            user.ResidentialAddress.HouseNumber = "4444";
            user.ResidentialAddress.Street = "Sub Street";
            user.ResidentialAddress.City = "Mysuru";
            user.ResidentialAddress.Contact.CountryCode = "57";
            user.ResidentialAddress.Contact.Number = "33003300";

            // assert
            Assert.NotEqual(user.ResidentialAddress.HouseNumber, user.CommunicationAddress.HouseNumber);
            Assert.NotEqual(user.ResidentialAddress.Street, user.CommunicationAddress.Street);
            Assert.NotEqual(user.ResidentialAddress.City, user.CommunicationAddress.City);
            Assert.NotEqual(user.ResidentialAddress.Contact.CountryCode, user.CommunicationAddress.Contact.CountryCode);
            Assert.NotEqual(user.ResidentialAddress.Contact.Number, user.CommunicationAddress.Contact.Number);
        }
    }
}
