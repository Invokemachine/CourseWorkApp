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
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void LogOutMethod()
        {
            MainWindow.isSignedIn = false;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void ToFlightsMethod()
        {
            FlightsWindow flightsWindow = new FlightsWindow();
            flightsWindow.Show();
            Close();
        }
        private void ToCountries()
        {
            CountriesListWindow countriesListWindow = new CountriesListWindow();
            countriesListWindow.Show();
            Close();
        }
        private void ToDocuments()
        {
            PersonalInformationWindow personalInformationWindow = new PersonalInformationWindow();
            personalInformationWindow.Show();
            Close();
        }

        private void WhereToGoButton_Click(object sender, RoutedEventArgs e)
        {
            ToCountries();
        }

        private void BuyTicketButton_Click(object sender, RoutedEventArgs e)
        {
            ToFlightsMethod();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LogOutMethod();
        }

        private void DocumentsButton_Click(object sender, RoutedEventArgs e)
        {
            ToDocuments();
        }
    }
}
