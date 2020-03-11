using XF.FluentUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace XF.FluentUI.Views
{
    public class MainPage : BaseContentPage<MainViewModel>
    {
        public MainPage()
        {
            Title = "Home";
            BackgroundColor = Color.FromHex("#e3e3e3");

            Content = new Grid
            {
                Children =
                {
                    new StackLayout {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(20,0),

                        Children =
                        {
                            new Label { HorizontalTextAlignment = TextAlignment.Center , TextColor = Color.FromHex("#212121") }
                                .Bind(Label.TextProperty, nameof(MainViewModel.Message)),

                            new Button { HorizontalOptions = LayoutOptions.Fill, Text = "Do something" }
                                .Bind(Button.CommandProperty, nameof(MainViewModel.NavigateToSecondPageCommand))

                        }
                    }
                }
            };
        }
    }
}
