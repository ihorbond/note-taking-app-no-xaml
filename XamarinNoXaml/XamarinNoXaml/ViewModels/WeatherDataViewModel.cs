using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinNoXaml.Models;
using XamarinNoXaml.Services;

namespace XamarinNoXaml.ViewModels
{
    public class WeatherDataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command GetWeatherCommand { get; }
        public Command GoBackCommand { get; }
        WeatherService WeatherService { get; }
        string cityName = null;
        public string CityName
        {
            get => cityName;
            set
            {
                cityName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CityName)));
                GetWeatherCommand.ChangeCanExecute();
            }
        }
        WeatherData weatherData;
        public WeatherData WeatherData
        {
            get => weatherData;
            set
            {
                weatherData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WeatherData)));
            }
        }


        public WeatherDataViewModel()
        {
            //DotNetEnv.Env.Load("../.env");
            WeatherService = new WeatherService();

            GetWeatherCommand = new Command(
            execute: async () =>
            {
                var endpoint = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_ENDPOINT");
                WeatherData = await WeatherService.GetWeatherDataAsync(GenerateRequestUri(Constants.OPEN_WEATHER_MAP_ENDPOINT));
            },
            canExecute: () => !string.IsNullOrEmpty(CityName));

            GoBackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={CityName}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OPEN_WEATHER_MAP_KEY}";
            return requestUri;
        }

    }
}
