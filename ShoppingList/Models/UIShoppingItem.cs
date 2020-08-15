using System;
using ShoppingList.Core;
using ShoppingList.Database;

namespace ShoppingList.Models
{
    public class UIShoppingItem : IShoppingItem
    {
        public string Name { get; set; }
        public ShoppingItemState State { get; set; }
        public DateTime LastBought { get; set; }
        public string StateText => State.GetDescription();
    }
}
