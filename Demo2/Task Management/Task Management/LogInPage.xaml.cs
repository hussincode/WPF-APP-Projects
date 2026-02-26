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

namespace Task_Management
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        private TaskManagementEntities context;
        public LogInPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context = new TaskManagementEntities();
            
            

            var user = new Persone()
            {
                Email = TXTUsername.Text,
                Password = TXTPass.Password,
                Role = "",
            };

            


            var valid = context.Persones.FirstOrDefault(m => m.Email == TXTUsername.Text && m.Password == TXTPass.Password);
            var role = context.Persones.FirstOrDefault(m => m.Role == "Manager");
            if (valid == null)
            {
                MessageBox.Show("the password or email is not correct",
                    "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            MessageBox.Show("Login succed");
            




        }
    }
}
