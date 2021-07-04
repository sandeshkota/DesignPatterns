using Xunit;
using DesignPatterns.StructuralPatterns.BridgePattern.Display;
using DesignPatterns.StructuralPatterns.BridgePattern.ItemService;
using DesignPatterns.StructuralPatterns.BridgePattern.Product;

namespace DesignPatternTests.StructuralPatterns.BridgePattern
{
    [Trait("Pattern", "Structural")]
    public class BridgePatternTest
    {
        [Fact]
        public void Book_Card_Display() {
            var book = new Book { Name = "Harry Potter", BookPhoto = "harry_potter.jpg", Synopsis = "Fantasy" };
            IItemService bookService = new BookItemService(book);
            Display cardDisplay = new CardDisplay(bookService);

            var displayData = cardDisplay.Show();

            Assert.Equal("Harry Potter<br/>harry_potter.jpg<br/>Fantasy", displayData);
        }

        [Fact]
        public void Book_Thumbnail_Display() {
            var book = new Book { Name = "Harry Potter", BookPhoto = "harry_potter.jpg", Synopsis = "Fantasy" };
            IItemService bookService = new BookItemService(book);
            Display thumbDisplay = new ThumbNailDisplay(bookService);

            var displayData = thumbDisplay.Show();

            Assert.Equal("harry_potter.jpg<br/>Harry Potter", displayData);
        }

        [Fact]
        public void Artist_Card_Display() {
            var artist = new Artist { Name = "JK Rowling", ProfilePhoto = "jk_rowling.jpg", Bio = "From UK" };
            IItemService artistService = new ArtistItemService(artist);
            Display cardDisplay = new CardDisplay(artistService);

            var displayData = cardDisplay.Show();

            Assert.Equal("JK Rowling<br/>jk_rowling.jpg<br/>From UK", displayData);
        }

        [Fact]
        public void Artist_Thumbnail_Display() {
            var artist = new Artist { Name = "JK Rowling", ProfilePhoto = "jk_rowling.jpg", Bio = "From UK" };
            IItemService artistService = new ArtistItemService(artist);
            Display thumbDisplay = new ThumbNailDisplay(artistService);

            var displayData = thumbDisplay.Show();

            Assert.Equal("jk_rowling.jpg<br/>JK Rowling", displayData);
        }
    }
}
