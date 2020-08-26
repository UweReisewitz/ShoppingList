using System;
using System.Diagnostics;
using AutoMapper;
using Prism.Navigation;
using PropertyChanged;
using ShoppingList.Core;
using ShoppingList.Database;
using ShoppingList.Database.Model;

namespace ShoppingList.Models
{
    [AddINotifyPropertyChangedInterface]
    public class UIShoppingItem
    {
        public UIShoppingItem(ShoppingItem shoppingItem)
            : this(shoppingItem, false)
        {
        }

        public UIShoppingItem(ShoppingItem shoppingItem, bool isNewShoppingItem)
        {
            DbShoppingItem = shoppingItem;
            IsNewShoppingItem = isNewShoppingItem;
        }

        public bool IsNewShoppingItem { get; }

        public ShoppingItem DbShoppingItem { get; }
        public Guid Id
        {
            get => DbShoppingItem.Id;
            set => DbShoppingItem.Id = value;
        }
        public string Name
        {
            get => DbShoppingItem.Name;
            set => DbShoppingItem.Name = value;
        }
        public ShoppingItemState State
        {
            get => DbShoppingItem.State;
            set => DbShoppingItem.State = value;
        }
        public DateTime LastBought
        {
            get => DbShoppingItem.LastBought;
            set => DbShoppingItem.LastBought = value;
        }

        [DependsOn(nameof(State))]
        public string StateText => State.GetDescription();
    }
}
