using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingList.Services;
using ShoppingList.Views;
using ShoppingList.Database;
using ShoppingList.ViewModels;

namespace ShoppingList
{
    public partial class App : Application
    {
        public App(IDbServiceFactory dbServiceFactory, ViewModelLocator viewModelLocator)
        {
            if (dbServiceFactory == null)
            {
                throw new ArgumentNullException(nameof(dbServiceFactory));
            }

            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            var dbService = dbServiceFactory.CreateNew();

            dbService.CreateOrUpdateDatabase();

            this.Resources.Add("ViewModelLocator", viewModelLocator);

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
