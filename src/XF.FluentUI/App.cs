using System;
using XF.FluentUI.Views;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace XF.FluentUI
{
    public class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; set; }

        public App()
        {
            Device.SetFlags(new[] { "Markup_Experimental" });

            Startup.Init();

            MainPage = new NavigationPage(Resolve<MainPage>());
        }

        public static T Resolve<T>() => ServiceProvider.GetService<T>();
    }
}
