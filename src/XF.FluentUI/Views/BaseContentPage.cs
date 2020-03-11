using XF.FluentUI.ViewModels;
using Xamarin.Forms;

namespace XF.FluentUI.Views
{
    public class BaseContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        public BaseContentPage() => BindingContext = ViewModel;

        protected object[] NavigationParams { get; private set; } = new object[] { };

        protected TViewModel ViewModel { get; } = App.Resolve<TViewModel>();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (ViewModel as INavigationAware)?.OnNavigatedTo(NavigationParams);
        }

        protected override void OnDisappearing()
        {
            (ViewModel as INavigationAware)?.OnNavigatingFrom();
            base.OnDisappearing();

        }

        public void SetParams(params object[] parameters)
        {
            NavigationParams = parameters;
        }
    }
}