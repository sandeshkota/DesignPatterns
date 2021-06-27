using Xunit;
using DesignPatterns.BehavioralPatterns.CommandPattern;
using DesignPatterns.BehavioralPatterns.CommandPattern.Commands;
using Xunit.Abstractions;

namespace DesignPatternTests.BehavioralPatterns.CommandPattern
{
    public class CommandPatternTest
    {
        private readonly ITestOutputHelper output;
        public CommandPatternTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Brightness_Increase_Test()
        {
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.IncreaseBrightness();

            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel + 2} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel + 2, photo.BrightnessLevel);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Brightness_Decrease_Test()
        {
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.DecreaseBrightness();

            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel - 2} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel - 2, photo.BrightnessLevel);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Brightness_Test()
        {
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.IncreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.IncreaseBrightness();
            photoEditor.IncreaseBrightness();

            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel + 4} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel + 4, photo.BrightnessLevel);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Add_Vivid_Filter_Test()
        {
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.AddVividFilter();

            Assert.Contains(vividFilter, photo.Filters);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Remove_Vivid_Filter_Test()
        {
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.AddVividFilter();
            photoEditor.RemoveVividFilter();

            Assert.DoesNotContain(vividFilter, photo.Filters);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Brightness_Increase_Undo_Test()
        {
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.IncreaseBrightness();
            photoEditor.Undo();

            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel, photo.BrightnessLevel);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Brightness_Decrease_Undo_Test()
        {
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.DecreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.Undo();

            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel - 2} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel-2, photo.BrightnessLevel);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Brightness_Undo_Test()
        {
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.IncreaseBrightness();
            photoEditor.IncreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.Undo();

            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel + 4} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel + 4, photo.BrightnessLevel);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Vivid_Filter_Undo_Test()
        {
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.AddVividFilter();
            photoEditor.Undo();

            Assert.DoesNotContain(vividFilter, photo.Filters);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Vivid_Undo_Test()
        {
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.AddVividFilter();
            photoEditor.RemoveVividFilter();
            photoEditor.Undo();

            Assert.Contains(vividFilter, photo.Filters);
        }


        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Undo_Test()
        {
            var vividFilter = "VIVID";
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            photoEditor.IncreaseBrightness();
            photoEditor.IncreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.AddVividFilter();
            photoEditor.RemoveVividFilter();
            photoEditor.AddVividFilter();

            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();
            photoEditor.Undo();

            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel, photo.BrightnessLevel);
            Assert.DoesNotContain(vividFilter, photo.Filters);
        }
    }
}
