using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using Avalonia.Platform;

namespace TravelPlanner1
{

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CountryComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (CountryComboBox.SelectedItem is ComboBoxItem selected)
            {
                var obrazek = new Uri($"avares://TravelPlanner1/Assets/{selected.Content}.jpg");
                var stream = AssetLoader.Open(obrazek);
                CountryImage.Source = new Bitmap(stream);
            }
        }

        

        private void AddCity_Click(object? sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                CitiesListBox.Items.Add(CityTextBox.Text);
                CityTextBox.Text = "";
            }

        }

        private void ShowDetails_Click(object? sender, RoutedEventArgs e)
        {
            var podsumowanie = new Podsumowanie();
            podsumowanie.Show(); 
        }
    }
}