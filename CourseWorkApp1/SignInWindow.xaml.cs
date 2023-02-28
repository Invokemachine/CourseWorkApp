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
        static public User currentUser;
        private SignUpWindow signUpWindow = new();
        private MainWindow mainWindow = new();

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
                MessageBox.Show("Input the data!");
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
                
                using FlightsDataBaseContext db = new();
                loginUser = db.Users.Where(expected => expected.PhoneNumber == phonenumber && expected.Password == password).FirstOrDefault();
                
                if (loginUser == null)
                {
                    MessageBox.Show("User not found!");
                    return;
                }
                else
                {
                    if (loginUser != null)
                    {
                        currentUser = loginUser;
                        MessageBox.Show("You logged in successfully!");
                        MainWindow.isSignedIn = true;
                        HomeWindow homeWindow = new();
                        homeWindow.Show();
                        Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("20% detected", "Something went wrong!");
                        return;
                    }
                }
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            LogInUserMethod();
        }

        private void Away_Click(object sender, RoutedEventArgs e)
        {
            ToSignUpMethod();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackMethod();
        }
    }
}
