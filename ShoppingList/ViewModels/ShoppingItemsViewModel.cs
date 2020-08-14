using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using PropertyChanged;
using ShoppingList.Database;
using ShoppingList.Models;
using ShoppingList.Services;
using ShoppingList.Views;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ShoppingItemsViewModel : ViewModelBase
    {
        private readonly IDbService dbService;

        public ShoppingItemsViewModel(IDbService dbService)
        {
            this.dbService = dbService;

            Title = "Shopping List";

            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

        }

        public ShoppingItemsViewModel(IDbServiceFactory dbServiceFactory)
        {
            dbService = dbServiceFactory?.CreateNew() ?? throw new ArgumentNullException(nameof(dbServiceFactory));

        }
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        private Item selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        public override void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => selectedItem;
            set
            {
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}