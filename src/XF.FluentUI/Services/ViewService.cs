using System;
using System.Threading.Tasks;
using XF.FluentUI.Views;

namespace XF.FluentUI.Services
{
    public class ViewService : IViewService
    {
        public async Task GoHome()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        public async Task ShowPageTwo(string message)
        {
            var page = App.Resolve<SecondPage>();
            page.SetParams(message);
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
