using Autofac;
using Foundation;
using ShoppingList.Core;
using ShoppingList.Database;
using UIKit;

namespace ShoppingList.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);
            var container = builder.Build();

            // Initialize SQLite
            SQLitePCL.Batteries_V2.Init();

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            var application = new App(container.Resolve<IDbServiceFactory>());
            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<PlatformSpecialFolder>().As<IPlatformSpecialFolder>().SingleInstance();
            builder.RegisterType<DbServiceFactory>().As<IDbServiceFactory>().SingleInstance();
        }
    }
}
