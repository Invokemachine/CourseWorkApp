using CourseWorkApp1;
using Microsoft.Data.Sqlite;
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
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public static User currentUser;
        private SignUpWindow signUpWindow = new SignUpWindow();
        private MainWindow mainWindow = new MainWindow();

        public SignInWindow()
        {
            InitializeComponent();
        }

        public void BackMethod()
        {
            mainWindow.Show();
            Close();
        }

        public void ToSignUpMethod()
        {
            signUpWindow.Show();
            Close();
        }

        private void LogInUserMethod()
        {
            if (string.IsNullOrEmpty(PhoneNumberTextBox.Text) || string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Введите данные");
                return;
            }
            long phonenumber = Convert.ToInt64(PhoneNumberTextBox.Text.Trim());
            string password = PasswordTextBox.Text.Trim();

            if (Convert.ToString(phonenumber).Length < 1)
            {
                MessageBox.Show("biba 1");
            }
            else if (password.Length < 3)
            {
                MessageBox.Show("biba 2");
            }
            else
            {
                User loginUser = null;
                using (FlightsDataBaseContext db = new FlightsDataBaseContext())
                {
                    loginUser = db.Users.Where(expected => expected.PhoneNumber == phonenumber
                    && expected.Password == password).FirstOrDefault();

                    if (loginUser == null)
                    {
                        MessageBox.Show("Mega biba");
                        return;
                    }
                    else
                    {
                        if (loginUser != null)
                        {
                            currentUser = loginUser;
                            MessageBox.Show("You logged in successfully!");
                            MainWindow.isSignedIn = true;
                            HomeWindow homeWindow = new HomeWindow();
                            homeWindow.Show();
                            return;
                        }

                        else
                        {
                            MessageBox.Show("20% detected", "Ooops. Some biba has just acquired");
                            return;
                        }
                    }
                }
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            LogInUserMethod();
            //MessageBox.Show("кнопачька работаит");
        }

        private void away_Click(object sender, RoutedEventArgs e)
        {
            ToSignUpMethod();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackMethod();
        }
    }
}
