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
        public void User_Save_Success_Test()
        {
            var user = new User { Name = "Sandesh" };
            user.Save();

            Assert.Equal("India", user.Location);
            Assert.True(user.IsSaved, "Couldn't save the user");
            Assert.True(user.Id != default && user.Id > 0, "User Id not set after save");
        }

        [Fact]
        public void User_Save_Failure_Test()
        {
            var user = new User { Name = "SK" };
            user.Save();

            Assert.NotEqual("India", user.Location);
            Assert.False(user.IsSaved, "user saved with only 4 characters");
            Assert.True(user.Id == default || user.Id <= 0, "User Id is set even when save failed");
        }

        [Fact]
        public void Product_Save_Success_Test()
        {
            var product = new Product { Name = "Phone", Price = 100.00 };
            product.Save();

            Assert.True(product.IsSaved, "Couldn't save the product");
            Assert.True(product.Id != default && product.Id > 0, "Product Id not set after save");
        }

        [Fact]
        public void Product_Save_Failure_Test()
        {
            var product = new Product();
            product.Save();

            Assert.False(product.IsSaved, "user saved with only 4 characters");
            Assert.True(product.Id == default || product.Id <= 0, "Product Id is set even when save failed");
        }
    }
}
