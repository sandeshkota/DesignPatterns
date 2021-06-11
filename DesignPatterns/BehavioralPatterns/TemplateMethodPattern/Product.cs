using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethodPattern
{
    public class Product : Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        protected override ValidationMessage Validate()
        {
            var validationMessage = new ValidationMessage();

            if (string.IsNullOrEmpty(this.Name) || this.Name.Length < 4)
            {
                validationMessage.ErrorMessages.Add("Product Name is mandatory and should have minimum 5 characters");
            }

            if (this.Price == default || this.Price < 0.00)
            {
                validationMessage.ErrorMessages.Add("Product Price should be greater than 0.00");
            }

            return validationMessage;
        }

        protected override void AfterSave(int id)
        {
            this.Id = id;
        }
    }
}
