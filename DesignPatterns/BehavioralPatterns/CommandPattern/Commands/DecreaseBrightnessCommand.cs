using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class DecreaseBrightnessCommand : ICommand
    {
        private const int STEPPER = 2;
        private Photo _photo;
        public DecreaseBrightnessCommand(Photo photo)
        {
            this._photo = photo;
        }

        public void Execute()
        {
            this._photo.BrightnessLevel -= STEPPER;
            Console.WriteLine($"Photo brightness decreased by {STEPPER} and is at {_photo.BrightnessLevel} level");
        }

        public void UnExecute()
        {
            this._photo.BrightnessLevel += STEPPER;
            Console.WriteLine($"Decreased brightness increased by {STEPPER} and is at {_photo.BrightnessLevel} level");
        }
    }
}
