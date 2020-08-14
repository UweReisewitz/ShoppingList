using System;
using System.Collections.Generic;
using System.Text;
using ShoppingList.Database;

namespace ShoppingList.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IDbServiceFactory dbServiceFactory;

        public ViewModelLocator(IDbServiceFactory dbServiceFactory)
        {
            this.dbServiceFactory = dbServiceFactory;
        }

        public ShoppingItemsViewModel ShoppingItems => new ShoppingItemsViewModel(dbServiceFactory.CreateNew());
    }
}
