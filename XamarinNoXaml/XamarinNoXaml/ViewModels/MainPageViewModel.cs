using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinNoXaml.Models;

namespace XamarinNoXaml.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<NoteModel> Notes { get; }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));

                //SaveCommand.ChangeCanExecute();
            }
        }

        private string noteText;

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

            EraseCommand = new Command(() =>
            {
                NoteText = String.Empty;
                Notes.Clear();
            });

        }

        
    }
}
