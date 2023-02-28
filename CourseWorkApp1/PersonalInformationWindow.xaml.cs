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
 
        /// !!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        public PersonalInformationWindow()
        {
            InitializeComponent();
            InitUserData();
        }

        private void InitUserData()
        {
            if (SignInWindow.currentUser != null)
            {
                EmailTextBox.Text = SignInWindow.currentUser.Email;
                NameTextBox.Text = SignInWindow.currentUser.Fullname;
                CitizenshipTextBox.Text = SignInWindow.currentUser.Citizenship;
                PassportIdTextBox.Text = Convert.ToString(SignInWindow.currentUser.PassportId);
                PassportSeriesTextBox.Text = Convert.ToString(SignInWindow.currentUser.PassportSeries);
            }
            else
            {
                MessageBox.Show("Biba");
                HomeWindow homeWindow = new();
                Close();
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

        private void SaveChangesMethod()
        {
            if (SignInWindow.currentUser != null)
            {
                SignInWindow.currentUser.Email = EmailTextBox.Text;
                SignInWindow.currentUser.Fullname = NameTextBox.Text;
                SignInWindow.currentUser.Citizenship = CitizenshipTextBox.Text;
                if (Int64.TryParse(PassportIdTextBox.Text, out long i) == false || Int64.TryParse(PassportSeriesTextBox.Text, out long j) == false)
                {
                    MessageBox.Show("Infortmation that you used in Passport Id or Passport Series is not a number or empty!");
                    return;
                }
                else
                {
                    SignInWindow.currentUser.PassportId = Convert.ToInt64(PassportIdTextBox.Text);
                    SignInWindow.currentUser.PassportSeries = Convert.ToInt64(PassportSeriesTextBox.Text);
                    try
                    {
                        db.Update(SignInWindow.currentUser);
                        db.SaveChanges();
                        MessageBox.Show("Information was updated!", "80% detected");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        MessageBox.Show("pumba");
                    }
                }
            }
            else
            {
                MessageBox.Show("User is empty!", "Fatal error");
                return;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            SaveChangesMethod();
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
