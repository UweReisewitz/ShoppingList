﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Database.Model
{
    public class ShoppingItem 
    {
        public ShoppingItem()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "int")]
        public ShoppingItemState State { get; set; }

        public DateTime LastBought { get; set; }
    }
}
