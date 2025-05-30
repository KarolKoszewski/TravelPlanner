using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace TravelPlanner1
{

    public partial class MainWindow : Window
    {
        private Dictionary<string, string> CountryImages = new()
        {
            { "Włochy", "Assets/italy.jpg" },
            { "Japonia", "Assets/japan.jpg" },
            { "Norwegia", "Assets/norway.jpg" },
            { "USA", "Assets/usa.jpg" },
            { "Francja", "Assets/france.jpg" }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CountryComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                if (CountryComboBox.SelectedItem is ComboBoxItem selected)
                {
                    if (CountryImages.TryGetValue(selected.Content.ToString()!, out string path))
                    {
                        CountryImage.Source = new Bitmap(path);
                    }
                }
            }
        }

        private void AddCity_Click(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ShowDetails_Click(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}