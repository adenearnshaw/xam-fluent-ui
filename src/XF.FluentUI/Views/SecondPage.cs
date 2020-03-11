using XF.FluentUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace XF.FluentUI.Views
{
    public class SecondPage : BaseContentPage<SecondPageViewModel>
    {
        public SecondPage()
        {
            Title = "Second Page";
            BackgroundColor = Color.FromHex("#e3e3e3");

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(20, 0),

                Children =
                {
                    new Label { HorizontalTextAlignment = TextAlignment.Center , TextColor = Color.FromHex("#212121") }
                        .Bind(Label.TextProperty, nameof(SecondPageViewModel.Message)),
                }
            };
        }
    }
}
