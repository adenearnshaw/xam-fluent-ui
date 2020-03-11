namespace XF.FluentUI.ViewModels
{
    public class SecondPageViewModel : BaseViewModel
    {
        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public override void OnNavigatedTo(params object[] navigationParam)
        {
            base.OnNavigatedTo(navigationParam);
            Message = navigationParam[0].ToString();
        }
    }
}
