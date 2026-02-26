using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for Employeepage.xaml
    /// </summary>
    public partial class Employeepage : Page
    {
        private TaskManagementEntities context;

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            Page_Loaded();
            loaded();
        }   
        public Employeepage()
        {
            InitializeComponent();
        }

        private void Page_Loaded()
        {
            LogInPage logInPage = new LogInPage();
            context = new TaskManagementEntities();
            LABUsername.Content = logInPage.TXTUsername.Text;
            context.Persones.Where(m => m.Email == logInPage.TXTUsername.Text).FirstOrDefault();
            DataContext = context.Persones.Where(m => m.Email == logInPage.TXTUsername.Text).FirstOrDefault();
            loaded();
        }

        private void loaded()
        {
            context = new TaskManagementEntities();
            datagrid.ItemsSource = context.Tasks.ToList();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                context = new TaskManagementEntities();
                datagrid.ItemsSource = context.Tasks.Where(m => m.Status == "Pending" || m.Status == "In Progress").ToList();

        }

 
        private void datagrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            context = new TaskManagementEntities();
            datagrid.ItemsSource = context.Tasks.Where(m => m.Status == "Completed").ToList();

        }

        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TXTTaskID.Text, out int id))
            {
                var task = context.Tasks.FirstOrDefault(u => u.TaskID == id);
                if (task != null)
                {
                    task.Status = TXTStatus.Text;
                    context.SaveChanges();
                    loaded();
                    MessageBox.Show("Updated successfully!",
                        "Updated",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }


            }
        }
    }
}
