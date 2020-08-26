using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Prism.Commands;
using Prism.Navigation;
using PropertyChanged;
using ShoppingList.Database;
using ShoppingList.Database.Model;
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

        public ShoppingItemsViewModel(INavigationService navigationService, IDbServiceFactory dbServiceFactory, IMapper mapper)
            : base(navigationService)
        {
            this.dbService = dbServiceFactory?.CreateNew() ?? throw new ArgumentNullException(nameof(dbServiceFactory));
            this.mapper = mapper;

            Title = "Shopping List";

            Items = new ObservableCollection<UIShoppingItem>();
            LoadItemsCommand = new DelegateCommand(async () => await ExecuteLoadItemsCommandAsync());

            ItemTapped = new Command<UIShoppingItem>(OnItemSelectedAsync);

            AddItemCommand = new DelegateCommand(async () => await OnAddItemAsync());

        }

        public ObservableCollection<UIShoppingItem> Items { get; private set; }
        public DelegateCommand LoadItemsCommand { get; }
        public DelegateCommand AddItemCommand { get; }
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
                    Items.Add(new UIShoppingItem(item, mapper));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private UIShoppingItem selectedItem;
        public UIShoppingItem SelectedItem
        {
            get => selectedItem;
            set => OnItemSelectedAsync(value);
        }

        private async Task OnAddItemAsync()
        {
            var dbShoppingItem = new ShoppingItem();
            dbService.AddShoppingItem(dbShoppingItem);
            var uiShoppingItem = new UIShoppingItem(dbShoppingItem, mapper);

            await NavigateToDetailPageAsync(uiShoppingItem);
        }

        private async void OnItemSelectedAsync(UIShoppingItem item)
        {
            if (item != null)
            {
                await NavigateToDetailPageAsync(item);
            }
        }

        private async Task NavigateToDetailPageAsync(UIShoppingItem uiShoppingItem)
        {
            var parameters = new NavigationParameters
                {
                    { "DbService", dbService },
                    { "Item", uiShoppingItem }
                };

            // This will push the ShoppingItemDetailPage onto the navigation stack
            await NavigationService.NavigateAsync("ShoppingItemDetailPage", parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                IsBusy = true;  // Refresh
            }
        }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            SelectedItem = null;

            await ExecuteLoadItemsCommandAsync();
        }
    }
}