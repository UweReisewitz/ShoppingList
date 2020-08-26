using System.Threading.Tasks;
using AutoMapper;
using Prism;
using Prism.Ioc;
using ShoppingList.Database;
using ShoppingList.ViewModels;
using ShoppingList.Views;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class App 
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await CreateOrMigrateDatabaseAsync();

            await NavigationService.NavigateAsync("NavigationPage/ShoppingItemsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var mapperconfiguration = new ShoppingListMapperConfiguration();

            containerRegistry.RegisterInstance<IMapper>(new MapperConfiguration(cfg => mapperconfiguration.CreateMapping(cfg)).CreateMapper());


            //containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ShoppingItemsPage, ShoppingItemsViewModel>();
            containerRegistry.RegisterForNavigation<ShoppingItemDetailPage, ShoppingItemDetailViewModel>();
        }

        private static async Task CreateOrMigrateDatabaseAsync()
        {
            var container = ((App)Application.Current).Container;

            var dbServiceFactory = container.Resolve<IDbServiceFactory>();
            var dbService = dbServiceFactory.CreateNew();
            await dbService.CreateOrMigrateDatabaseAsync();

        }
    }
}
