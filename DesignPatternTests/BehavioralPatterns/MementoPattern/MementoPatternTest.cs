using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DesignPatterns.BehavioralPatterns.MementoPattern;

namespace DesignPatternTests.BehavioralPatterns.MementoPattern
{
    public class MementoPatternTest
    {
        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Memento_Single_Backup_Test()
        {
            // arrange
            var originator = new Originator();
            var careTaker = new CareTaker();

            var photograph = new Photograph();
            photograph.BrightnessLevel += 20;
            photograph.AddFilter("VIVID");

            // act
            originator.SetPhotograph(photograph);
            originator.SaveToMemento(photograph);

            photograph.AddFilter("NATURE");
            var memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            var firstBackup = careTaker.GetMemento(0);
            var firstPhotograph = firstBackup.GetSavedPhotograph();

            // assert
            Assert.Equal(70, firstPhotograph.BrightnessLevel);
            Assert.Equal(2, firstPhotograph.GetFilters().Count);
            Assert.Contains("VIVID", firstPhotograph.GetFilters());
            Assert.Contains("NATURE", firstPhotograph.GetFilters());
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Memento_Double_Backup_Test()
        {
            // arrange
            var originator = new Originator();
            var careTaker = new CareTaker();

            var photograph = new Photograph();
            photograph.BrightnessLevel += 20;
            photograph.AddFilter("VIVID");

            // act
            originator.SetPhotograph(photograph);
            originator.SaveToMemento(photograph);

            photograph.AddFilter("NATURE");
            var memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            photograph.AddFilter("SNOWFALL");
            photograph.AddFilter("AUTUMN");
            memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            var firstBackup = careTaker.GetMemento(0);
            var firstPhotograph = firstBackup.GetSavedPhotograph();

            var secondBackup = careTaker.GetMemento(1);
            var secondPhotograph = secondBackup.GetSavedPhotograph();

            // assert
            Assert.Equal(70, firstPhotograph.BrightnessLevel);
            Assert.Equal(2, firstPhotograph.GetFilters().Count);
            Assert.Contains("VIVID", firstPhotograph.GetFilters());
            Assert.Contains("NATURE", firstPhotograph.GetFilters());

            Assert.Equal(70, secondPhotograph.BrightnessLevel);
            Assert.Equal(4, secondPhotograph.GetFilters().Count);
            Assert.Contains("VIVID", secondPhotograph.GetFilters());
            Assert.Contains("NATURE", secondPhotograph.GetFilters());
            Assert.Contains("SNOWFALL", secondPhotograph.GetFilters());
            Assert.Contains("AUTUMN", secondPhotograph.GetFilters());
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Memento_Multi_Backup_Test()
        {
            // arrange
            var originator = new Originator();
            var careTaker = new CareTaker();

            var photograph = new Photograph();
            photograph.BrightnessLevel += 20;
            photograph.AddFilter("VIVID");

            // act
            originator.SetPhotograph(photograph);
            originator.SaveToMemento(photograph);

            photograph.AddFilter("NATURE");
            var memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            photograph.AddFilter("SNOWFALL");
            photograph.AddFilter("AUTUMN");
            memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            photograph.BrightnessLevel -= 3;
            memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            var firstBackup = careTaker.GetMemento(0);
            var firstPhotograph = firstBackup.GetSavedPhotograph();

            var secondBackup = careTaker.GetMemento(1);
            var secondPhotograph = secondBackup.GetSavedPhotograph();

            var thirdBackup = careTaker.GetMemento(2);
            var thirdPhotograph = thirdBackup.GetSavedPhotograph();

            // assert
            Assert.Equal(70, firstPhotograph.BrightnessLevel);
            Assert.Equal(2, firstPhotograph.GetFilters().Count);
            Assert.Contains("VIVID", firstPhotograph.GetFilters());
            Assert.Contains("NATURE", firstPhotograph.GetFilters());

            Assert.Equal(70, secondPhotograph.BrightnessLevel);
            Assert.Equal(4, secondPhotograph.GetFilters().Count);
            Assert.Contains("VIVID", secondPhotograph.GetFilters());
            Assert.Contains("NATURE", secondPhotograph.GetFilters());
            Assert.Contains("SNOWFALL", secondPhotograph.GetFilters());
            Assert.Contains("AUTUMN", secondPhotograph.GetFilters());

            Assert.Equal(67, thirdPhotograph.BrightnessLevel);
            Assert.Equal(4, thirdPhotograph.GetFilters().Count);
            Assert.Contains("VIVID", thirdPhotograph.GetFilters());
            Assert.Contains("NATURE", thirdPhotograph.GetFilters());
            Assert.Contains("SNOWFALL", thirdPhotograph.GetFilters());
            Assert.Contains("AUTUMN", thirdPhotograph.GetFilters());
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Memento_No_Backup_Test()
        {
            // arrange
            var originator = new Originator();
            var careTaker = new CareTaker();

            var photograph = new Photograph();
            photograph.BrightnessLevel += 20;
            photograph.AddFilter("VIVID");

            // act
            originator.SetPhotograph(photograph);
            originator.SaveToMemento(photograph);

            photograph.AddFilter("NATURE");
            var memento = originator.SaveToMemento(photograph);

            photograph.AddFilter("SNOWFALL");
            photograph.AddFilter("AUTUMN");
            memento = originator.SaveToMemento(photograph);

            photograph.BrightnessLevel -= 3;
            memento = originator.SaveToMemento(photograph);

            var firstBackup = careTaker.GetMemento(0);

            // assert
            Assert.Null(firstBackup);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Memento_Loading_More_Backup_Test()
        {
            // arrange
            var originator = new Originator();
            var careTaker = new CareTaker();

            var photograph = new Photograph();
            photograph.BrightnessLevel += 20;
            photograph.AddFilter("VIVID");

            // act
            originator.SetPhotograph(photograph);
            originator.SaveToMemento(photograph);

            photograph.AddFilter("NATURE");
            var memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            photograph.AddFilter("SNOWFALL");
            photograph.AddFilter("AUTUMN");
            memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            photograph.BrightnessLevel -= 3;
            memento = originator.SaveToMemento(photograph);
            careTaker.AddMemento(memento);

            var firstBackup = careTaker.GetMemento(3);

            // assert
            Assert.Null(firstBackup);
        }
    }
}
