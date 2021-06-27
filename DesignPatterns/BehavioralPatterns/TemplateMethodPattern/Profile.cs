using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethodPattern
{
    public class Profile : Model
    {
        public string Description { get; set; }

        protected override ValidationMessage Validate()
        {
            return new ValidationMessage();
        }
    }
}
