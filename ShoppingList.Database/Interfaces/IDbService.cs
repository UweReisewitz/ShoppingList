using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ShoppingList.Database.Model;

namespace ShoppingList.Database
{
    public interface IDbService
    {
        Task CreateOrMigrateDatabaseAsync();

        void SaveChanges();
        Task SaveChangesAsync();

        Task<ObservableCollection<ShoppingItem>> GetShoppingListItemsAsync();

        Task AddShoppingItemAsync(ShoppingItem item);
        void RemoveShoppingItem(ShoppingItem item);
        Task EndShoppingAsync();

        ShoppingItem FindShoppingItem(string name);
        Task<ShoppingItem> FindShoppingItemAsync(string name);

        Task<List<string>> GetSuggestedNamesAsync(string name);


    }
}
