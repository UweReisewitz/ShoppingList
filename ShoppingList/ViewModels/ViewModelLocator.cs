using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ShoppingList.Database;

namespace ShoppingList.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IDbServiceFactory dbServiceFactory;
        private readonly IMapper mapper;

        public ViewModelLocator(IDbServiceFactory dbServiceFactory, IMapper mapper)
        {
            this.dbServiceFactory = dbServiceFactory;
            this.mapper = mapper;
        }

        public ShoppingItemsViewModel ShoppingItems => new ShoppingItemsViewModel(dbServiceFactory.CreateNew(), mapper);
        public ShoppingItemDetailViewModel ShoppingItemDetail => new ShoppingItemDetailViewModel();
    }
}
