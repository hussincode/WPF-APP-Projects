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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new LibraryDBEntities();
            var data = new User
            {
                Email = EmailTextBox.Text,
                Password = PasswordBox.Password
            };
            var validation = context.Users.FirstOrDefault(u => u.Email == EmailTextBox.Text && u.Password == PasswordBox.Password);
            if(validation == null)
            {
                MessageBox.Show("The Email or password is not correct",
                    "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          
            MessageBox.Show($"login sussed!",
                "Great",
                MessageBoxButton.OK, MessageBoxImage.Information);

            this.NavigationService.Navigate(new Home());


        }
        private void GoToSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUpPage());
        }
        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordVisibilityBox.Text = PasswordBox.Password;
            PasswordVisibilityBox.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Collapsed;

        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = PasswordVisibilityBox.Text;
            PasswordBox.Visibility = Visibility.Visible;
            PasswordVisibilityBox.Visibility = Visibility.Collapsed;
        }
    }
}
