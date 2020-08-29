using System;
using System.Diagnostics;
using System.IO;
using AutoMapper;
using Prism.Navigation;
using PropertyChanged;
using ShoppingList.Core;
using ShoppingList.Database;
using ShoppingList.Database.Model;
using Xamarin.Forms;

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

        public byte[] ImageData
        {
            get => DbShoppingItem.ImageData;
            set => DbShoppingItem.ImageData = value;
        }

        [DependsOn(nameof(State))]
        public string StateText => State.GetDescription();

        [DependsOn(nameof(ImageData))]
        public ImageSource ImageItem => ImageSource.FromStream(() => new MemoryStream(ImageData));

        [DependsOn(nameof(State))]
        public bool IsOpen => State == ShoppingItemState.Open;

        [DependsOn(nameof(State))]
        public bool IsBought => State == ShoppingItemState.Bought;
    }
}
