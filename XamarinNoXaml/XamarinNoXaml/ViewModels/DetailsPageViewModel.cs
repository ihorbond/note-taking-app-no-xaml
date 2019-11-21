using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinNoXaml.ViewModels
{
    public class DetailsPageViewModel : INotifyPropertyChanged
    {
        public ICommand GoBackCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        public DetailsPageViewModel()
        {
            GoBackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }
    }
}
