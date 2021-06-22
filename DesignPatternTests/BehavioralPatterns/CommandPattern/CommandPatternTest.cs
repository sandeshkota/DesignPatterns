using Xunit;
using DesignPatterns.BehavioralPatterns.CommandPattern;
using DesignPatterns.BehavioralPatterns.CommandPattern.Commands;

namespace DesignPatternTests.BehavioralPatterns.CommandPattern
{
    public class CommandPatternTest
    {
        [Fact]
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

            Assert.Equal(currentBrightnessLevel + 2, photo.BrightnessLevel);
        }

        [Fact]
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

            Assert.Equal(currentBrightnessLevel - 2, photo.BrightnessLevel);
        }

        [Fact]
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

            Assert.Equal(currentBrightnessLevel + 4, photo.BrightnessLevel);
        }

        [Fact]
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

            Assert.Equal(currentBrightnessLevel, photo.BrightnessLevel);
        }

        [Fact]
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

            Assert.Equal(currentBrightnessLevel-2, photo.BrightnessLevel);
        }

        [Fact]
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

            Assert.Equal(currentBrightnessLevel + 4, photo.BrightnessLevel);
        }

        [Fact]
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

            Assert.Equal(currentBrightnessLevel, photo.BrightnessLevel);
            Assert.DoesNotContain(vividFilter, photo.Filters);
        }
    }
}
