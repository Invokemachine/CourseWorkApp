using CourseWorkApp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWorkApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isSignedIn = false;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void TicketReservationButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have to sign in first!");
        }

        private void CheckAvailableFlights_Click(object sender, RoutedEventArgs e)
        {
            CountriesListWindow countriesListWindow = new CountriesListWindow();
            countriesListWindow.Show();
            Close();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            Close();
        }
    }
}
