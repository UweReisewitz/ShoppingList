using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Database
{
    public interface IDbService
    {
        void CreateOrUpdateDatabase();

        Task<List<IShoppingItem>> GetShoppingListItemsAsync();
    }
}
