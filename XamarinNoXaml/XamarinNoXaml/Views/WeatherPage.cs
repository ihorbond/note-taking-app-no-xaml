using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using XamarinNoXaml.Models;
using XamarinNoXaml.ViewModels;

namespace XamarinNoXaml.Views
{
    public class WeatherPage : ContentPage
    {
        Entry CityName;
        Button GetWeather;
        SwipeGestureRecognizer swipeDownGestureRecognizer;
        Label Location;
        Label Temperature;
        Label WindSpeed;
        Label Humidity;
        Label Visibility;
        WeatherDataViewModel WeatherDataViewModelInstance;

        public WeatherPage(WeatherDataViewModel viewModel)
        {
            BindingContext = viewModel;
            WeatherDataViewModelInstance = viewModel;

            InitializeUIElements();
            InitializeUIGrid();
        }

        public void InitializeUIElements()
        {
            CityName = new Entry
            {
                Placeholder = "Enter city",
                Margin = new Thickness(10, 10),
            };
            CityName.SetBinding(Entry.TextProperty, nameof(WeatherDataViewModel.CityName));

            GetWeather = new Button
            {
                Text = "Get Weather",
                BackgroundColor = Color.Green,
                Margin = new Thickness(5, 10),
            };
            GetWeather.SetBinding(Button.CommandProperty, nameof(WeatherDataViewModel.GetWeatherCommand));

            Location = new Label
            {
                FontSize = 16,
                TextColor = Color.Black
            };
            Location.SetBinding(
                Label.TextProperty,
                $"{nameof(WeatherData)}.{nameof(WeatherData.Title)}",
                stringFormat: "City: {0}"
                );

            Temperature = new Label
            {
                FontSize = 16,
                TextColor = Color.Black
            };
            Temperature.SetBinding(
                Label.TextProperty,
                $"{nameof(WeatherData)}.{nameof(WeatherData.Main)}.{nameof(WeatherData.Main.Temperature)}",
                stringFormat: "Temperature: {0}° F"
                );

            WindSpeed = new Label
            {
                FontSize = 16,
                TextColor = Color.Black
            };
            WindSpeed.SetBinding(
                Label.TextProperty, 
                $"{nameof(WeatherData)}.{nameof(WeatherData.Wind)}.{nameof(WeatherData.Wind.Speed)}",
                stringFormat: "Wind Speed: {0} mph"
                );

            Humidity = new Label
            {
                FontSize = 16,
                TextColor = Color.Black
            };
            Humidity.SetBinding(
                Label.TextProperty, 
                $"{nameof(WeatherData)}.{nameof(WeatherData.Main)}.{nameof(WeatherData.Main.Humidity)}", 
                stringFormat: "Humidity: {0}%"
                );

            Visibility = new Label
            {
                FontSize = 16,
                TextColor = Color.Black
            };
            Visibility.SetBinding(
                Label.TextProperty,
                $"{nameof(WeatherData)}.{nameof(WeatherData.Visibility)}",
                stringFormat: "Visibility: {0}"
                );

            swipeDownGestureRecognizer = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Down,
            };
            swipeDownGestureRecognizer.SetBinding(SwipeGestureRecognizer.CommandProperty, nameof(WeatherDataViewModel.GoBackCommand));
        }

        public void InitializeUIGrid()
        {
            var stackLayout = new StackLayout
            {
                Spacing = 5,
                Orientation = StackOrientation.Vertical,
            };

            stackLayout.Children.Add(CityName);
            stackLayout.Children.Add(GetWeather);
            stackLayout.Children.Add(Location);
            stackLayout.Children.Add(Temperature);
            stackLayout.Children.Add(Humidity);
            stackLayout.Children.Add(WindSpeed);
            stackLayout.Children.Add(Visibility);

            stackLayout.GestureRecognizers.Add(swipeDownGestureRecognizer);

            //Debug.WriteLine("=========================================");
            //Debug.WriteLine(stackLayout.Children[2]);
            //Debug.WriteLine(stackLayout.Children[2].BindingContext ?? "NULL");
            //Debug.WriteLine("=========================================");

            Content = stackLayout;
        }
    }
}
