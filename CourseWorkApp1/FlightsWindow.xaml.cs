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
using System.Windows.Shapes;

namespace CourseWorkApp1
{
    /// <summary>
    /// Логика взаимодействия для FlightsWindow.xaml
    /// </summary>
    public partial class FlightsWindow : Window
    {
        private Flight currentFlight;
        private FlightsDataBaseContext db = new FlightsDataBaseContext();

        public FlightsWindow()
        {
            InitializeComponent();
            using (var db = new FlightsDataBaseContext())
            {
                FlightsDataGrid.ItemsSource = db.Flights.ToList();
            }
        }

        private void BackMethod()
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
            Close();
        }

        private void SearchMethod()
        {
            var currentFlight = db.Flights.ToList();
            currentFlight = currentFlight.Where(p => p.CityName.Contains(SearchTextBox.Text.ToLower())).ToList();
            FlightsDataGrid.ItemsSource = currentFlight.OrderBy(p => p.Country).ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackMethod();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMethod();
        }

        private void ReserveMethod()
        {
            var newTakenFlight = new TakenFlight()
            {
                UserIdCheck = SignInWindow.currentUser.Id,
                Quantity = 1,
                FlightId = currentFlight.Id,
                CityName = currentFlight.CityName,
                Time = currentFlight.Time,
                Date = currentFlight.DateTime,
                Price = currentFlight.Price,
                Status = "Not payed"
            };

            if (newTakenFlight.UserIdCheck != null)
            {
                db.TakenFlights.Add(newTakenFlight);
                db.SaveChanges();

                MessageBox.Show("Ticket was reserved!", "80% detected");
                SignInWindow signInWindow = new SignInWindow();
                signInWindow.Show();
                Close();
                return;
            }
            else
            {
                MessageBox.Show("Gabella has happened", "20% detected");
                return;
            }
        }

        private void BuyTicketButton_Click(object sender, RoutedEventArgs e)
        {
            ReserveMethod();
        }

        private void FlightsDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            currentFlight = (Flight)FlightsDataGrid.SelectedItem;
        }
    }
}
