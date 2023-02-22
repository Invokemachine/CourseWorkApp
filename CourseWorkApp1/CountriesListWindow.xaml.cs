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
    /// Логика взаимодействия для CountriesListWindow.xaml
    /// </summary>
    public partial class CountriesListWindow : Window
    {
        public User currentUser;
        private Country currentCountry;
        public CountriesListWindow()
        {
            InitializeComponent();
            using (var db = new FlightsDataBaseContext())
            {
                CountriesDataGrid.ItemsSource = db.Countries.ToList();
            }
        }

        private void BackMethod()
        {
            if (MainWindow.isSignedIn == false)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
                Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackMethod();
        }

        private void CountryInformationShow()
        {
            AboutCountryWindow aboutCountryWindow = new AboutCountryWindow(currentCountry);
            aboutCountryWindow.Show();
            Close();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            CountryInformationShow();
        }

        private void CountriesDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            currentCountry = (Country)CountriesDataGrid.SelectedItem;
        }
    }
}

