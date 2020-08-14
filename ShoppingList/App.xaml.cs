using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingList.Services;
using ShoppingList.Views;
using ShoppingList.Database;

namespace ShoppingList
{
    public partial class App : Application
    {
        private readonly IDbServiceFactory dbServiceFactory;

        public App(IDbServiceFactory dbServiceFactory)
        {
            if (dbServiceFactory == null)
            {
                throw new ArgumentNullException(nameof(dbServiceFactory));
            }

            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            this.dbServiceFactory = dbServiceFactory;

            var dbService = dbServiceFactory.CreateNew();

            dbService.CreateOrUpdateDatabase();

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
