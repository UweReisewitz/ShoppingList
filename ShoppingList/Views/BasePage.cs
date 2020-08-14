using System;
using System.Collections.Generic;
using System.Text;
using ShoppingList.ViewModels;
using Xamarin.Forms;

namespace ShoppingList.Views
{
    public class BasePage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = this.BindingContext as ViewModelBase;
            vm?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var vm = this.BindingContext as ViewModelBase;
            vm?.OnDisappearing();
        }
    }
}
