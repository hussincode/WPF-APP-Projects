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

namespace task_manegemt
{
    /// <summary>
    /// Interaction logic for Log_In_Page.xaml
    /// </summary>
    public partial class Log_In_Page : Page
    {
        private TaskMEntities context = new TaskMEntities();
        User1 user;
        public Log_In_Page()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = TXTemail.Text;
            string PasswordBox = TXTpass.Password;
            
            user = context.User1.FirstOrDefault(u => u.Email == TXTemail.Text);
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(PasswordBox))
            {
                MessageBox.Show("All field are requerd",
                    "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (user != null)
            {
                user.Email = email;
                user.Password = PasswordBox;
                string role = user.Role;

                user.Role = role;
                


                switch (role)
                {
                    case "Employee":
                        this.NavigationService.Navigate(new View_Tasks_Page());
                        break;
                    case "Manager":
                        this.NavigationService.Navigate(new User_Management_Page());
                        break;

                }
                context.SaveChanges();
                MessageBox.Show("login!",
                    "Great",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                
                

            }
            else if(user.Password != PasswordBox)
            {
                MessageBox.Show("Password or email is not correct",
                    "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error); 
                return;
            }
            else
            {
                MessageBox.Show("signup plese",
                    "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
