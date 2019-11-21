using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinNoXaml.Models
{
    public class WeatherData: INotifyPropertyChanged
    {
        private string title;
        [JsonProperty("name")]
        public string Title
        {
            get => title;
            set
            {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Visibility { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
