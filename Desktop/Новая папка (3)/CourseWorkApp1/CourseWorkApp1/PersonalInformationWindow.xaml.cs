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
    public partial class PersonalInformationWindow : Window
    {
        private FlightsDataBaseContext db = new FlightsDataBaseContext();
        public User currentUser;
        public PersonalInformationWindow()
        {
            InitializeComponent();
            using (var db = new FlightsDataBaseContext())
            {
                
            }
        }

        private void BackMethod()
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
            Close();
        }

        private void ToPayment()
        {
            PaymentWindow paymentWindow = new PaymentWindow();
            paymentWindow.Show();
            Close();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            currentUser = SignInWindow.currentUser;
            currentUser.Email = EmailTextBox.Text;
            currentUser.Fullname = NameTextBox.Text;
            currentUser.Citizenship = CitizenshipTextBox.Text;
            currentUser.PassportId = Convert.ToInt64(PassportIdTextBox.Text);
            currentUser.PassportSeries = Convert.ToInt64(PassportSeriesTextBox.Text);
            try
            {
                db.SaveChanges();
                MessageBox.Show("Information was updated!", "80% detected");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            ToPayment();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackMethod();
        }
    }
}
