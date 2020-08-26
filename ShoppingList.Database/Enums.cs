using System.ComponentModel;

namespace ShoppingList.Database
{
    public enum ShoppingItemState
    {
        [Description("Offen")]
        Open = 0,
        [Description("Gekauft")]
        Bought = 1,
        [Description("Einkauf abgeschlossen")]
        ShoppingComplete = 2
    }
}
