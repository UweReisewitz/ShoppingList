using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Prism;
using Prism.Ioc;
using ShoppingList.Core;
using ShoppingList.Database;

namespace ShoppingList.Droid
{
    [Activity(Label = "ShoppingList", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App(new AndroidInitializer()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPlatformSpecialFolder, PlatformSpecialFolder>();
            containerRegistry.RegisterSingleton<IDbServiceFactory, DbServiceFactory>();
            // Register any platform specific implementations
        }
    }
}