using System;

namespace ShoppingList.Database
{
    public interface IShoppingItem
    {
        string Name { get; set; }
        ShoppingItemState State { get; set; }
        DateTime LastBought { get; set; }
    }
}
