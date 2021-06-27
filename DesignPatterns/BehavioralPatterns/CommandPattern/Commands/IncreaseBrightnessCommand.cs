using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class IncreaseBrightnessCommand : ICommand
    {
        private  const int STEPPER = 2;
        private readonly Photo _photo;
        public IncreaseBrightnessCommand(Photo photo)
        {
            this._photo = photo;
        }

        public void Execute()
        {
            this._photo.BrightnessLevel += STEPPER;
            Console.WriteLine($"Photo brightness increased by {STEPPER} and is at {_photo.BrightnessLevel} level");
        }

        public void UnExecute()
        {
            this._photo.BrightnessLevel -= STEPPER;
            Console.WriteLine($"Increased brightness decreased by {STEPPER} and is at {_photo.BrightnessLevel} level");
        }
    }
}
