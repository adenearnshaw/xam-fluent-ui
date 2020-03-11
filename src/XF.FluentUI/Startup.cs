using System.IO;
using System.Reflection;
using XF.FluentUI.Services;
using XF.FluentUI.ViewModels;
using XF.FluentUI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;

namespace XF.FluentUI
{
    public class Startup
    {
        private static string ConfigFileName = $"{nameof(XF)}.{nameof(FluentUI)}.appsettings";

        public static void Init()
        {
            var systemDir = FileSystem.CacheDirectory;
            ExtractSaveResource($"{ConfigFileName}.json", systemDir);

            //#if RELEASE
            ExtractSaveResource($"{ConfigFileName}.production.json", systemDir);
            //#endif

            var fullConfig = Path.Combine(systemDir, $"{ConfigFileName}.json");
            var productionConfig = Path.Combine(systemDir, $"{ConfigFileName}.production.json");

            var host = new HostBuilder()
                            .ConfigureHostConfiguration(c =>
                            {
                                c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                                c.AddJsonFile(fullConfig);
                                c.AddJsonFile(productionConfig, true);
                            })
                            .ConfigureServices((c, x) =>
                            {
                                ConfigureServices(c, x);
                                ConfigureViews(c, x);
                            })
                            .ConfigureLogging((ctx, logging) =>
                            {
                                logging.AddConsole(o =>
                                {
                                    o.DisableColors = true;
                                });
                            })
                            .Build();


            App.ServiceProvider = host.Services;
        }



        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            // Services
            services.AddTransient<IViewService, ViewService>();

            // Viewmodels
            services.AddTransient<MainViewModel>();
            services.AddTransient<SecondPageViewModel>();
        }

        private static void ConfigureViews(HostBuilderContext ctx, IServiceCollection services)
        {
            // Pages
            services.AddTransient<MainPage>();
            services.AddTransient<SecondPage>();
        }

        private static void ExtractSaveResource(string filename, string location)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }

                }
            }
        }
    }
}
