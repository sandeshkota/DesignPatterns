using DesignPatterns.StructuralPatterns.BridgePattern.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.BridgePattern.ItemService
{
    public class BookItemService : IItemService
    {
        private readonly Book _book;
        public BookItemService(Book book)
        {
            this._book = book;
        }

        public string GetImageUrl()
        {
            return this._book.BookPhoto;
        }

        public string GetSummary()
        {
            return this._book.Synopsis;
        }

        public string GetTitle()
        {
            return this._book.Name;
        }
    }
}
