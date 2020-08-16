using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Database
{
    public interface IDbService
    {
        Task CreateOrMigrateDatabaseAsync();

        Task<List<IShoppingItem>> GetShoppingListItemsAsync();
    }
}
