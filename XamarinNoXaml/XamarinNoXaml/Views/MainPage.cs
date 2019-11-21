using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinNoXaml.Models;
using XamarinNoXaml.ViewModels;
using XamarinNoXaml.Views;

namespace XamarinNoXaml
{
    public class MainPage : ContentPage
    {
        Image codeSpaceImage;
        Editor noteEditor;
        Button saveButton, eraseButton;
        CollectionView notesList;

        public MainPage()
        {
            InitializeUIElements();
            InitializeUIGrid();
        }

        private void InitializeUIElements()
        {
            BackgroundColor = Color.PowderBlue;

            BindingContext = new MainPageViewModel();

            codeSpaceImage = new Image
            {
                Source = "codespace.png",
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, nameof(MainPageViewModel.ShowWeatherCommand));
            codeSpaceImage.GestureRecognizers.Add(tapGestureRecognizer);

            noteEditor = new Editor
            {
                Placeholder = "Enter Note",
                BackgroundColor = Color.White,
                Margin = new Thickness(10)
            };
            noteEditor.SetBinding(Editor.TextProperty, nameof(MainPageViewModel.NoteText));

            saveButton = new Button
            {
                Text = "Save",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                Margin = new Thickness(5),
            };
            saveButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.SaveCommand));

            eraseButton = new Button
            {
                Text = "Erase",
                TextColor = Color.White,
                BackgroundColor = Color.Red,
                Margin = new Thickness(5)
            };
            eraseButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.EraseCommand));

            notesList = new CollectionView
            {
                SelectionMode = SelectionMode.Single,
                ItemTemplate = new NotesTemplate()
            };
            notesList.SetBinding(ItemsView.ItemsSourceProperty, nameof(MainPageViewModel.Notes));
            notesList.SetBinding(SelectableItemsView.SelectedItemProperty, nameof(MainPageViewModel.SelectedNote));
            notesList.SetBinding(SelectableItemsView.SelectionChangedCommandProperty, nameof(MainPageViewModel.NoteSelectedCommand));
        }

        private void InitializeUIGrid()
        {
            var cols = new ColumnDefinitionCollection()
            {
                 new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            };
            var rows = new RowDefinitionCollection()
            {
                 new RowDefinition { Height = new GridLength(1,GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1.5,GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1,GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(2,GridUnitType.Star) }
            };

            Grid grid = new Grid
            {
                ColumnDefinitions = cols,
                RowDefinitions = rows
            };

            grid.Children.Add(codeSpaceImage, 0, 0);
            grid.Children.Add(noteEditor, 0, 1);
            grid.Children.Add(saveButton, 0, 2);
            grid.Children.Add(eraseButton, 1, 2);
            grid.Children.Add(notesList, 0, 3);
            grid.Children.ForEach(c =>
            {
                if(c is Button == false)
                    Grid.SetColumnSpan(c, grid.ColumnDefinitions.Count);
            });

            Content = grid;
        }
    }

    class NotesTemplate : DataTemplate
    {
        public NotesTemplate() : base(LoadTemplate)
        {

        }

        static StackLayout LoadTemplate()
        {
            var textLabel = new Label();
            textLabel.SetBinding(Label.TextProperty, nameof(NoteModel.Text));

            var frame = new Frame
            {
                VerticalOptions = LayoutOptions.Center,
                Content = textLabel
            };

            return new StackLayout
            {
                Children = { frame },
                Padding = new Thickness(10, 10)
            };
        }
    }
}