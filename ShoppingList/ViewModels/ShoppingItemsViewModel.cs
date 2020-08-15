using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using PropertyChanged;
using ShoppingList.Database;
using ShoppingList.Models;
using ShoppingList.Views;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ShoppingItemsViewModel : ViewModelBase
    {
        private readonly IDbService dbService;
        private readonly IMapper mapper;

        public ShoppingItemsViewModel(IDbService dbService, IMapper mapper)
        {
            this.dbService = dbService;
            this.mapper = mapper;

            Title = "Shopping List";

            Items = new ObservableCollection<UIShoppingItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommandAsync());

            ItemTapped = new Command<UIShoppingItem>(OnItemSelectedAsync);

            AddItemCommand = new Command(OnAddItem);

        }

        public ShoppingItemsViewModel(IDbServiceFactory dbServiceFactory)
        {
            dbService = dbServiceFactory?.CreateNew() ?? throw new ArgumentNullException(nameof(dbServiceFactory));

        }

        public ObservableCollection<UIShoppingItem> Items { get; private set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<UIShoppingItem> ItemTapped { get; }

        private async Task ExecuteLoadItemsCommandAsync()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await dbService.GetShoppingListItemsAsync();

                foreach (var item in items)
                {
                    Items.Add(mapper.Map<UIShoppingItem>(item));
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        private UIShoppingItem selectedItem;
        public UIShoppingItem SelectedItem
        {
            get => selectedItem;
            set => OnItemSelectedAsync(value);
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        private async void OnItemSelectedAsync(UIShoppingItem item)
        {
            if (item != null)
            {
                // This will push the ShoppingItemDetailPage onto the navigation stack
                await Shell.Current.GoToAsync($"{nameof(ShoppingItemDetailPage)}");
            }
        }
    }
}