using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoXaml.Models;
using XamarinNoXaml.Views;

namespace XamarinNoXaml.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<NoteModel> Notes { get; }

        public Command ShowWeatherCommand { get; }
        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public Command NoteSelectedCommand { get; }
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
            }
        }

        private string noteText;
        private NoteModel selectedNote;

        public MainPageViewModel()
        {
            Notes = new ObservableCollection<NoteModel>();
            SaveCommand = new Command(() =>
            {
                if((NoteText ?? "").Length > 0)
                {
                    var note = new NoteModel
                    {
                        Title = NoteText.ToUpper(),
                        Text = NoteText,
                        TimeStamp = DateTime.Now
                    };

                    Notes.Add(note);
                    NoteText = String.Empty;
                }
                
            });

            ShowWeatherCommand = new Command(async() =>
            {
                var weatherDataViewModel = new WeatherDataViewModel();
                await Application.Current.MainPage.Navigation.PushModalAsync(new WeatherPage(weatherDataViewModel));
            });

            EraseCommand = new Command(() =>
            {
                NoteText = String.Empty;
                Notes.Clear();
            });

            NoteSelectedCommand = new Command(async() =>
            {
                if (SelectedNote is null) return;

                var detailsPageViewModel = new DetailsPageViewModel
                {
                    NoteText = SelectedNote.Text
                };

                await Application.Current.MainPage.Navigation.PushModalAsync(new DetailsPage(detailsPageViewModel));

                SelectedNote = null;
            });
        }

        
    }
}
