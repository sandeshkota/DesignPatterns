using DesignPatterns.StructuralPatterns.BridgePattern.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.BridgePattern.ItemService
{
    public class ArtistItemService : IItemService
    {
        private readonly Artist _artist;
        public ArtistItemService(Artist artist)
        {
            this._artist = artist;
        }

        public string GetImageUrl()
        {
            return this._artist.ProfilePhoto;
        }

        public string GetSummary()
        {
            return this._artist.Bio;
        }

        public string GetTitle()
        {
            return this._artist.Name;
        }
    }
}
