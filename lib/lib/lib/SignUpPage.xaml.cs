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

namespace lib
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

      
        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new login());
        }

        private void SignUpButton_Click_1(object sender, RoutedEventArgs e)
        {
            
            var context = new LibraryDBEntities();
            string role = "";
            if (RadioLibrarian.IsChecked == true)
            {
                role = "Librarian";
            }
            else if (RadioMember.IsChecked == true)
            {
                role = "Member";
            }

            var NewUser = new User()
            {
                FullName = UsernameTextBox.Text,
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Password,
                Role = role
            };

            string pass1 = PasswordTextBox.Password;
            string pass2 = ConfirmPasswordTextBox.Password;

            if(string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(UsernameTextBox.Text) || string.IsNullOrEmpty(PasswordTextBox.Password))
            {
                MessageBox.Show("You must field all requerd",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if(context.Users.Any(u => u.Email == EmailTextBox.Text))
            {
                MessageBox.Show("The acount are created Before!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if(pass1 != pass2)
            {
                MessageBox.Show("The Password and the Confirm Password are not matched",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return;
            }

            if(pass1.Length < 6 || !pass1.Any(char.IsUpper) || !pass1.Any(char.IsDigit))
            {
                MessageBox.Show("The Password must be 6 char and have uper case letter and numbers",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

           

            else if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("You must chose a role",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            context.Users.Add(NewUser);
            context.SaveChanges();


            MessageBox.Show("Account is created correctly",
                "Great!",
                MessageBoxButton.OK,
                MessageBoxImage.Information);


            this.NavigationService.Navigate(new Home());
        }

        private void Check(object sender, EventArgs e)
        {
            passwordvisable.Text = PasswordTextBox.Password;
            passwordvisable.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Collapsed;
        }

        private void unCheck(object sender, EventArgs e)
        {
            PasswordTextBox.Password = passwordvisable.Text;
            PasswordTextBox.Visibility = Visibility.Visible;
            passwordvisable.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new login());
        }
    }
}
