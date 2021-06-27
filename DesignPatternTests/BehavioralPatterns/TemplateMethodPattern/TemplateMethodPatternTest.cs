using DesignPatterns.BehavioralPatterns.TemplateMethodPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatternTests.BehavioralPatterns.TemplateMethodPattern
{
    public class TemplateMethodPatternTest
    {
        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void User_Save_Success_Test()
        {
            // arrange
            var user = new User { Name = "Sandesh" };

            // act
            user.Save();

            // assert
            Assert.Equal("India", user.Location);
            Assert.True(user.IsSaved, "Couldn't save the user");
            Assert.True(user.Id != default && user.Id > 0, "User Id not set after save");
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void User_Save_Small_Name_Failure_Test()
        {
            // arrange
            var user = new User { Name = "SK" };

            // act
            user.Save();

            // assert
            Assert.NotEqual("India", user.Location);
            Assert.False(user.IsSaved, "user saved with only 4 characters");
            Assert.True(user.Id == default || user.Id <= 0, "User Id is set even when save failed");
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void User_Save_Null_Name_Failure_Test()
        {
            // arrange
            var user = new User();

            // act
            user.Save();

            // assert
            Assert.NotEqual("India", user.Location);
            Assert.False(user.IsSaved, "user saved with only 4 characters");
            Assert.True(user.Id == default || user.Id <= 0, "User Id is set even when save failed");
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Product_Save_Success_Test()
        {
            // arrange
            var product = new Product { Name = "Phone", Price = 100.00 };

            // act
            product.Save();

            // assert
            Assert.True(product.IsSaved, "Couldn't save the product");
            Assert.True(product.Id != default && product.Id > 0, "Product Id not set after save");
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Product_Save_Failure_Test()
        {
            // arrange
            var product = new Product();

            // act
            product.Save();

            // assert
            Assert.False(product.IsSaved, "user saved with only 4 characters");
            Assert.True(product.Id == default || product.Id <= 0, "Product Id is set even when save failed");
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Profile_Save_Test()
        {
            // arrange
            var profile = new Profile { Description = "" };

            // act
            profile.Save();

            // assert
            Assert.True(profile.IsSaved, "Profile saved successfully");
        }
    }
}
