using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var atrakcje = new List<string>();
            if (MuseumsCheckBox.IsChecked == true) atrakcje.Add("Muzea");
            if (ParksCheckBox.IsChecked == true) atrakcje.Add("Parki Narodowe");
            if (MonumentsCheckBox.IsChecked == true) atrakcje.Add("Zabytki");
            if (RestaurantsCheckBox.IsChecked == true) atrakcje.Add("Restauracje");
            if (GalleriesCheckBox.IsChecked == true) atrakcje.Add("Galerie sztuki");
            if (FestivalsCheckBox.IsChecked == true) atrakcje.Add("Festiwale i koncerty");

            var transport = "";
            if (PlaneRadio.IsChecked == true) transport = "Samolot";
            if (CarRadio.IsChecked == true) transport = "Samochód";
            if (TrainRadio.IsChecked == true) transport = "Pociąg";
            if (ShipRadio.IsChecked == true) transport = "Statek";

            var podsumowanie = new Podsumowanie();

            var podsumowanieText = $"""
                                    Imię i nazwisko: {NameTextBox.Text}
                                    Wybrany kraj: {(CountryComboBox.SelectedItem as ComboBoxItem)?.Content}
                                    Wybrane atrakcje:{string.Join(",\n", atrakcje)}
                                    Transport: {transport}
                                    Miasta do odwiedzenia:
                                    {string.Join("\n", CitiesListBox.Items.Cast<string>().Select(miasto => miasto))}
                                    """;

            var textBlockPodsumowanie = podsumowanie.Find<TextBlock>("PodsumowanieText");
            textBlockPodsumowanie!.Text = podsumowanieText;

            podsumowanie.ShowDialog(this);

        }
    }
}