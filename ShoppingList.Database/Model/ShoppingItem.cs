using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Database.Model
{
    public class ShoppingItem : IShoppingItem
    {
        [Key]
        public string Name { get; set; }
        
        [Column(TypeName = "int")]
        public ShoppingItemState State { get; set; }
        
        public DateTime LastBought { get; set; }
    }
}
