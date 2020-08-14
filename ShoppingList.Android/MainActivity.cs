
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Autofac;
using ShoppingList.Core;
using ShoppingList.Database;
using ShoppingList.ViewModels;

namespace ShoppingList.Droid
{
    [Activity(Label = "ShoppingList", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            var builder = new ContainerBuilder();
            ConfigureContainer(builder);
            var container = builder.Build();


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var app = new App(container.Resolve<IDbServiceFactory>(), container.Resolve<ViewModelLocator>());
            LoadApplication(app);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<PlatformSpecialFolder>().As<IPlatformSpecialFolder>().SingleInstance();
            builder.RegisterType<DbServiceFactory>().As<IDbServiceFactory>().SingleInstance();
            builder.RegisterType<ViewModelLocator>().SingleInstance();
        }

    }
}