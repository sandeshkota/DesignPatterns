using DesignPatterns.StructuralPatterns.BridgePattern.ItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.BridgePattern.Display
{
    public class CardDisplay : Display
    {
        private IItemService _itemService;
        public CardDisplay(IItemService itemService) : base(itemService)
        {
            this._itemService = itemService;
        }

        public override string Show()
        {
            return $"{this._itemService.GetTitle()}<br/>{this._itemService.GetImageUrl()}<br/>{this._itemService.GetSummary()}";
        }
    }
}
