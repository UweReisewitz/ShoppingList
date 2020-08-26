using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Prism.Navigation;
using PropertyChanged;
using ShoppingList.Core;
using ShoppingList.Database;
using ShoppingList.Database.Model;
using ShoppingList.Models;

namespace ShoppingList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ShoppingItemDetailViewModel : ViewModelBase
    {
        private readonly IMapper mapper;

        private IDbService dbService;
        private UIShoppingItem shoppingItem;

        public ShoppingItemDetailViewModel(INavigationService navigationService, IMapper mapper)
            : base(navigationService)
        {
            Title = "Detail View";
            this.mapper = mapper;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        private ShoppingItemState itemState;
        public ShoppingItemState State
        {
            get => itemState;
            set
            {
                if (value != itemState)
                {
                    if (itemState == ShoppingItemState.Open)
                    {
                        LastBought = DateTime.Now;
                    }
                    itemState = value;
                }
            }
        }

        public IList<EnumValueDescription> ItemStateList => typeof(ShoppingItemState).ToList();

        [DependsOn(nameof(State))]
        public EnumValueDescription ItemState
        {
            get => new EnumValueDescription(State, State.GetDescription());
            set => State = (ShoppingItemState)value.EnumValue;
        }

        public DateTime LastBought { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            dbService = (IDbService)parameters["DbService"];
            shoppingItem = (UIShoppingItem)parameters["Item"];
            mapper.Map(shoppingItem, this);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            if (dbService != null && shoppingItem != null)
            {
                mapper.Map(this, shoppingItem);
                dbService.SaveChanges();
            }

        }
    }
}
