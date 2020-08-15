using System;
using AutoMapper;
using ShoppingList.Database;
using ShoppingList.Models;

namespace ShoppingList
{
    public class ShoppingListMapperConfiguration
    {
        public void CreateMapping(IMapperConfigurationExpression configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration.CreateMap<IShoppingItem, UIShoppingItem>();
        }

    }
}
