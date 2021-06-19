using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethodPattern
{
    public class User : Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }


        protected override ValidationMessage Validate()
        {
            var validationMessage = new ValidationMessage();

            if (string.IsNullOrEmpty(this.Name) || this.Name.Length < 4)
            {
                validationMessage.ErrorMessages.Add("User Name is mandatory and should have minimum 5 characters");
            }

            return validationMessage;
        }

        protected override void BeforeSave()
        {
            if (string.IsNullOrEmpty(this.Location))
            {
                this.Location = "India";
            }
        }

        protected override void AfterSave(int id)
        {
            this.Id = id;
        }
    }
}
