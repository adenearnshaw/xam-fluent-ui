using System.Windows.Input;
using XF.FluentUI.Services;
using Xamarin.Forms;

namespace XF.FluentUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IViewService _viewService;

        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public ICommand NavigateToSecondPageCommand { get; set; }

        public MainViewModel(IViewService viewService)
        {
            _viewService = viewService;
            NavigateToSecondPageCommand = new Command(NavigateToSecondPage);
        }

        public override void OnNavigatedTo(params object[] navigationParam)
        {
            base.OnNavigatedTo(navigationParam);

            Message = "Hey folks";
        }

        private void NavigateToSecondPage()
        {
            _viewService.ShowPageTwo("This text was sent from the home page");
        }
    }
}