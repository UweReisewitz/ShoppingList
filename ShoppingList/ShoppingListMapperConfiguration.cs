using System;
using AutoMapper;
using ShoppingList.Models;
using ShoppingList.ViewModels;

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

            configuration.CreateMap<Database.Model.ShoppingItem, UIShoppingItem>().ReverseMap();
            configuration.CreateMap<UIShoppingItem, ShoppingItemDetailViewModel>().ReverseMap();
        }

    }
}
