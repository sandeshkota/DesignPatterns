﻿using Xunit;
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
        public void Brightness_Increase_Test()
        {
            // arrange
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.IncreaseBrightness();

            // assert
            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel + 2} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel + 2, photo.BrightnessLevel);
        }

        [Fact]
        public void Brightness_Decrease_Test()
        {
            // arrange
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.DecreaseBrightness();

            // assert
            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel - 2} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel - 2, photo.BrightnessLevel);
        }

        [Fact]
        public void Brightness_Test()
        {
            // arrange
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.IncreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.IncreaseBrightness();
            photoEditor.IncreaseBrightness();

            // assert
            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel + 4} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel + 4, photo.BrightnessLevel);
        }

        [Fact]
        public void Add_Vivid_Filter_Test()
        {
            // arrange
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.AddVividFilter();

            // assert
            Assert.Contains(vividFilter, photo.Filters);
        }

        [Fact]
        public void Remove_Vivid_Filter_Test()
        {
            // arrange
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.AddVividFilter();
            photoEditor.RemoveVividFilter();

            // assert
            Assert.DoesNotContain(vividFilter, photo.Filters);
        }

        [Fact]
        public void Brightness_Increase_Undo_Test()
        {
            // arrange
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.IncreaseBrightness();
            photoEditor.Undo();

            // assert
            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel, photo.BrightnessLevel);
        }

        [Fact]
        public void Brightness_Decrease_Undo_Test()
        {
            // arrange
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.DecreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.Undo();

            // assert
            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel - 2} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel-2, photo.BrightnessLevel);
        }

        [Fact]
        public void Brightness_Undo_Test()
        {
            // arrange
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.IncreaseBrightness();
            photoEditor.IncreaseBrightness();
            photoEditor.DecreaseBrightness();
            photoEditor.Undo();

            // assert
            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel + 4} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel + 4, photo.BrightnessLevel);
        }

        [Fact]
        public void Vivid_Filter_Undo_Test()
        {
            // arrange
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.AddVividFilter();
            photoEditor.Undo();

            // assert
            Assert.DoesNotContain(vividFilter, photo.Filters);
        }

        [Fact]
        public void Vivid_Undo_Test()
        {
            // arrange
            var vividFilter = "VIVID";
            var photo = new Photo();
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
            photoEditor.AddVividFilter();
            photoEditor.RemoveVividFilter();
            photoEditor.Undo();

            // assert
            Assert.Contains(vividFilter, photo.Filters);
        }


        [Fact]
        public void Undo_Test()
        {
            // arrange
            var vividFilter = "VIVID";
            var photo = new Photo();
            var currentBrightnessLevel = photo.BrightnessLevel;
            var increaseBrightnessCommand = new IncreaseBrightnessCommand(photo);
            var decreaseBrightnessCommand = new DecreaseBrightnessCommand(photo);
            var addVividFilterCommand = new AddVividFilterCommand(photo);
            var removeVividFilterCommand = new RemoveVividFilterCommand(photo);
            var photoEditor = new PhotoEditor(increaseBrightnessCommand, decreaseBrightnessCommand,
                                                addVividFilterCommand, removeVividFilterCommand);

            // act
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

            // assert
            this.output.WriteLine($"Expected Brightness level is {currentBrightnessLevel} & Actual Brightness level is {photo.BrightnessLevel}");
            Assert.Equal(currentBrightnessLevel, photo.BrightnessLevel);
            Assert.DoesNotContain(vividFilter, photo.Filters);
        }
    }
}
