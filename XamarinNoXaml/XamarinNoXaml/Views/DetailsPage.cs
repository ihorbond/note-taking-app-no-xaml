using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinNoXaml.ViewModels;

namespace XamarinNoXaml.Views
{
    public class DetailsPage: ContentPage
    {
        public DetailsPage(DetailsPageViewModel viewModel)
        {
            BindingContext = viewModel;
            BackgroundColor = Color.PowderBlue;

            var textLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            textLabel.SetBinding(Label.TextProperty, nameof(DetailsPageViewModel.NoteText));

            var backButton = new Button
            {
                Text = "Go Back",
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(20),
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 20
            };
            backButton.SetBinding(Button.CommandProperty, nameof(DetailsPageViewModel.GoBackCommand));

            var downSwipeGestureRecognizer = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Down
            };
            downSwipeGestureRecognizer.SetBinding(SwipeGestureRecognizer.CommandProperty, nameof(DetailsPageViewModel.GoBackCommand));

            var stackLayout = new StackLayout
            {
                Margin = new Thickness(20, 40)
            };
            stackLayout.Children.Add(textLabel);
            stackLayout.Children.Add(backButton);
            stackLayout.GestureRecognizers.Add(downSwipeGestureRecognizer);

            Content = stackLayout;
        }
    }
}
