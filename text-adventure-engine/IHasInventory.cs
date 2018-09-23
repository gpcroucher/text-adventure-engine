using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    interface IHasInventory
    {
        Inventory Contents { get; }

        void AddToInventory<T>(T item) where T : Thing;
        bool Contains(string itemName);
        bool Contains<T>(T item) where T: Thing;
        List<string> GetListOfContents();
        dynamic RemoveFromInventory(string itemName);
        T RemoveFromInventory<T>(T item) where T : Thing;
    }
}
