using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class RemoveVividFilterCommand : ICommand
    {
        private const string FILTER = "VIVID";
        private Photo _photo;
        public RemoveVividFilterCommand(Photo photo)
        {
            this._photo = photo;
        }

        public void Execute()
        {
            if (this._photo.Filters != null && this._photo.Filters.Contains(FILTER))
            {
                this._photo.Filters.Remove(FILTER);
                Console.WriteLine($"{FILTER} is removed from the photo");

            }
        }

        public void UnExecute()
        {
            if (this._photo.Filters != null && !this._photo.Filters.Contains(FILTER))
            {
                this._photo.Filters.Add(FILTER);
                Console.WriteLine($"Removed {FILTER} is added to the photo");

            }
        }
    }
}
