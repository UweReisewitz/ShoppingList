using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Prism.Commands;
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
        private UIShoppingItem uiShoppingItem;

        public ShoppingItemDetailViewModel(INavigationService navigationService, IMapper mapper)
            : base(navigationService)
        {
            Title = "Detail View";
            this.mapper = mapper;

            UpdateSuggestedNames = new DelegateCommand<bool?>(async (bool? performUpdate) => await PerformUpdateSuggestedNamesAsync(performUpdate));
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


        public DelegateCommand<bool?> UpdateSuggestedNames { get; }
        private async Task PerformUpdateSuggestedNamesAsync(bool? performUpdate)
        {
            if (performUpdate.HasValue && performUpdate.Value)
            {
                SuggestedNames = await dbService.GetSuggestedNames(Name);
            }
            else
            {
                SuggestedNames = null;
            }
        }

        public List<string> SuggestedNames { get; private set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            dbService = (IDbService)parameters["DbService"];
            uiShoppingItem = (UIShoppingItem)parameters["Item"];
            mapper.Map(uiShoppingItem, this);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            if (dbService != null && uiShoppingItem != null)
            {
                var oldItem = dbService.FindShoppingItem(Name);
                if (oldItem != null)
                {
                    if (uiShoppingItem.IsNewShoppingItem)
                    {
                        dbService.RemoveShoppingItem(uiShoppingItem.DbShoppingItem);
                        LastBought = oldItem.LastBought;
                    }
                    uiShoppingItem = new UIShoppingItem(oldItem);
                    Id = uiShoppingItem.Id;
                }
                mapper.Map(this, uiShoppingItem);
                dbService.SaveChanges();
            }

        }
    }
}
