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
        private readonly IMapper mapper;
        private readonly ShoppingItem shoppingItem;

        public UIShoppingItem(ShoppingItem shoppingItem, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.shoppingItem = shoppingItem;
        }

        public Guid Id
        {
            get => shoppingItem.Id;
            set => shoppingItem.Id = value;
        }
        public string Name
        {
            get => shoppingItem.Name;
            set => shoppingItem.Name = value;
        }
        public ShoppingItemState State
        {
            get => shoppingItem.State;
            set => shoppingItem.State = value;
        }
        public DateTime LastBought
        {
            get => shoppingItem.LastBought;
            set => shoppingItem.LastBought = value;
        }

        [DependsOn(nameof(State))]
        public string StateText => State.GetDescription();
    }
}
