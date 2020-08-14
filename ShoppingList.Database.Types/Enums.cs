using System.ComponentModel;

namespace ShoppingList.Database
{
    public enum ShoppingItemState
    {
        [Description("Offen")]
        Open=1,
        [Description("Gekauft")]
        Bought=2,
        [Description("Einkauf abgeschlossen")]
        ShoppingComplete=3
    }
}
