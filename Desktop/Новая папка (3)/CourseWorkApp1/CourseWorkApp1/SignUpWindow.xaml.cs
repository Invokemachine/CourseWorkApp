using CourseWorkApp1;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private FlightsDataBaseContext db = new FlightsDataBaseContext();

        public SignUpWindow()
        {
            InitializeComponent();
            using (var db = new FlightsDataBaseContext())
            {
            }
        }

        private void SignUpUserMethod()
        {
            StringBuilder errors = new StringBuilder();

            if (String.IsNullOrEmpty(PhoneNumberTextBox.Text))
                errors.AppendLine("Enter your phone number!" + "\n");
            if (String.IsNullOrEmpty(PasswordTextBox.Text))
                errors.AppendLine("Enter Password!" + "\n");
            if (String.IsNullOrEmpty(RepeatPasswordTextBox.Text))
                errors.AppendLine("Passwords are not the same!" + "\n");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (int.TryParse(PhoneNumberTextBox.Text, out int i) != false)
                {
                    errors.AppendLine("gg!" + "\n");
                    if (PhoneNumberTextBox.Text != null && PasswordTextBox.Text != null && PasswordTextBox.Text == RepeatPasswordTextBox.Text)
                    {
                        var newUser = new User()
                        {
                            PhoneNumber = int.Parse(PhoneNumberTextBox.Text),
                            Password = PasswordTextBox.Text,
                        };

                        if (newUser.PhoneNumber != null && newUser.Password != null && PasswordTextBox.Text == RepeatPasswordTextBox.Text)
                        {
                            db.Users.Add(newUser);
                            db.SaveChanges();

                            MessageBox.Show("User account created!", "80% detected");
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
                    else
                    {
                        MessageBox.Show("biba has accured", "20% detected");
                        return;
                    }
                }
            }
        }

        private void BackToSignInMethod()
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpUserMethod();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackToSignInMethod();
        }
    }
}

