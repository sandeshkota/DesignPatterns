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
            var user = new User();
            user.Name = "Kota";
            user.PhoneNumber = "99887766";
            user.ResidentialAddress = new Address
            {
                HouseNumber = "333",
                Street = "Main Street",
                City = "Bengaluru",
                ZipCode = new ZipCode { Code = "ZC001" }
            };

            user.CopyResidentialAddressToCommunicationAddress();

            Assert.Equal(user.ResidentialAddress.HouseNumber, user.CommunicationAddress.HouseNumber);
            Assert.Equal(user.ResidentialAddress.Street, user.CommunicationAddress.Street);
            Assert.Equal(user.ResidentialAddress.City, user.CommunicationAddress.City);
            Assert.Equal(user.ResidentialAddress.ZipCode.Code, user.CommunicationAddress.ZipCode.Code);
        }

        [Fact]
        public void User_Address_Shallow_Copy_Change_Test()
        {
            var user = new User();
            user.Name = "Kota";
            user.PhoneNumber = "99887766";
            user.ResidentialAddress = new Address
            {
                HouseNumber = "333",
                Street = "Main Street",
                City = "Bengaluru",
                ZipCode = new ZipCode { Code = "ZC001" }
            };

            user.CopyResidentialAddressToCommunicationAddress();
            user.ResidentialAddress.HouseNumber = "4444";
            user.ResidentialAddress.Street = "Sub Street";
            user.ResidentialAddress.City = "Mysuru";
            user.ResidentialAddress.ZipCode.Code = "ZC002";

            Assert.NotEqual(user.ResidentialAddress.HouseNumber, user.CommunicationAddress.HouseNumber);
            Assert.NotEqual(user.ResidentialAddress.Street, user.CommunicationAddress.Street);
            Assert.NotEqual(user.ResidentialAddress.City, user.CommunicationAddress.City);
            Assert.Equal(user.ResidentialAddress.ZipCode.Code, user.CommunicationAddress.ZipCode.Code);
        }

        [Fact]
        public void User_Address_Deep_Copy_Change_Test()
        {
            var user = new User();
            user.Name = "Kota";
            user.PhoneNumber = "99887766";
            user.ResidentialAddress = new Address
            {
                HouseNumber = "333",
                Street = "Main Street",
                City = "Bengaluru",
                ZipCode = new ZipCode { Code = "ZC001" }
            };

            user.CopyCompleteResidentialAddressToCommunicationAddress();
            user.ResidentialAddress.HouseNumber = "4444";
            user.ResidentialAddress.Street = "Sub Street";
            user.ResidentialAddress.City = "Mysuru";
            user.ResidentialAddress.ZipCode.Code = "ZC002";

            Assert.NotEqual(user.ResidentialAddress.HouseNumber, user.CommunicationAddress.HouseNumber);
            Assert.NotEqual(user.ResidentialAddress.Street, user.CommunicationAddress.Street);
            Assert.NotEqual(user.ResidentialAddress.City, user.CommunicationAddress.City);
            Assert.NotEqual(user.ResidentialAddress.ZipCode.Code, user.CommunicationAddress.ZipCode.Code);
        }
    }
}
