﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ShoppingList.Database.Model;

namespace ShoppingList.Database
{
    public interface IDbService
    {
        Task CreateOrMigrateDatabaseAsync();

        Task SaveChangesAsync();

        void SaveChanges();

        Task<ObservableCollection<ShoppingItem>> GetShoppingListItemsAsync();

        void AddShoppingItem(ShoppingItem item);
        void RemoveShoppingItem(ShoppingItem item);
        Task EndShopping();

        ShoppingItem FindShoppingItem(string name);

        Task<List<string>> GetSuggestedNames(string name);


    }
}
