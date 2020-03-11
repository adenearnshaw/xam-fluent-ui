namespace XF.FluentUI.ViewModels
{
    public interface INavigationAware
    {
        void OnNavigatedTo(params object[] navigationParam);
        void OnNavigatingFrom();
    }
}
