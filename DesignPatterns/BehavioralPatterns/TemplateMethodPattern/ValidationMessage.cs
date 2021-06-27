using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethodPattern
{
    public class ValidationMessage
    {
        public bool HasError { 
            get {
                return ErrorMessages.Count > 0;
            } 
        }

        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
