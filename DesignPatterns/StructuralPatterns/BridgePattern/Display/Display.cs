using DesignPatterns.StructuralPatterns.BridgePattern.ItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.BridgePattern.Display
{
    public abstract class Display
    {
        private IItemService _itemService;
        public Display(IItemService itemService)
        {
            this._itemService = itemService;
        }

        public abstract string Show();
    }
}
