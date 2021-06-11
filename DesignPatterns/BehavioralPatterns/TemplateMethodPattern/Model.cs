using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethodPattern
{
    public abstract class Model
    {
        public bool IsSaved { get; set; }


        public void Save()
        {
            var validationMessage = this.Validate();
            if (validationMessage.HasError)
            {
                return;
            }

            this.BeforeSave();
            var id = this.SaveToDB();
            this.AfterSave(id);
        }

        protected abstract ValidationMessage Validate();

        protected virtual void BeforeSave() { }
        protected virtual void AfterSave(int id) { }

        protected int SaveToDB() {
            // save to DB
            this.IsSaved = true;

            return new Random().Next();
        }
    }
}
