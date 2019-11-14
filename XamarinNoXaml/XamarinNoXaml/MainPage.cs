using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamarinNoXaml
{
    public class MainPage : ContentPage
    {
        Image codeSpaceImage;
        Editor noteEditor;
        Label textLabel;
        Button saveButton, eraseButton;

        public MainPage()
        {
            InitializeUIElements();
            InitializeUIGrid();
        }

        private void InitializeUIElements()
        {
            BackgroundColor = Color.PowderBlue;

            codeSpaceImage = new Image
            {
                Source = "codespace.png"
            };

            noteEditor = new Editor
            {
                Placeholder = "Enter Note",
                BackgroundColor = Color.White,
                Margin = new Thickness(10)
            };

            saveButton = new Button
            {
                Text = "Save",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                Margin = new Thickness(10)
            };
            saveButton.Clicked += SaveButton_Clicked;

            eraseButton = new Button
            {
                Text = "Erase",
                TextColor = Color.White,
                BackgroundColor = Color.Red,
                Margin = new Thickness(10)
            };
            eraseButton.Clicked += EraseButton_Clicked;

            textLabel = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10)
            };
        }

        private void EraseButton_Clicked(object sender, EventArgs e)
        {
            noteEditor.Text = "";
            textLabel.Text = "";
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            textLabel.Text = noteEditor.Text;
            noteEditor.Text = "";
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
                 new RowDefinition { Height = new GridLength(2.5,GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1.5,GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(2,GridUnitType.Star) },
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
            grid.Children.Add(textLabel, 0, 3);
            grid.Children.ForEach(c =>
            {
                if(c is Button == false)
                    Grid.SetColumnSpan(c, grid.ColumnDefinitions.Count);
            });

            Content = grid;
        }
    }
}