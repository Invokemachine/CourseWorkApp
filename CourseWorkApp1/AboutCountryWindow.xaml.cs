using CourseWorkApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWorkApp
{
    /// <summary>
    /// Логика взаимодействия для AboutCountryWindow.xaml
    /// </summary>
    public partial class AboutCountryWindow : Window
    {
        public AboutCountryWindow(Country country)
        {
            InitializeComponent();
            CountryNameLabel.Content = country.Name;
            LanguageLabel.Content = country.Language;
            DistinguishmentsTextBox.Text = country.Distinguishments;

            if(country.Picture != null)
            {
                ForPicture.Source = new BitmapImage(new Uri($"C:/Users/AzatYTebiLove/source/repos/CourseWorkApp1/CourseWorkApp1/Resources/{country.Name}.jpg"));
            }
            else
            {
                ForPicture.Source = new BitmapImage(new Uri("C:/Users/AzatYTebiLove/source/repos/CourseWorkApp1/CourseWorkApp1/Resources/Main.png"));
            }
        }

        private void ToCountries()
        {
            if (MainWindow.isSignedIn == false)
            {
                MessageBox.Show("You have to sign in first!");
            }
            else
            {
                FlightsWindow flightsWindow = new FlightsWindow();
                flightsWindow.Show();
                Close();
            }
        }

        private void BackMethod()
        {
            CountriesListWindow countriesListWindow = new CountriesListWindow();
            countriesListWindow.Show();
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackMethod();
        }

        private void ToCountriesFlights_Click(object sender, RoutedEventArgs e)
        {
            ToCountries();
        }
    }
}
