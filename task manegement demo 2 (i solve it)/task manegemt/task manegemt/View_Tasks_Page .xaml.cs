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
    /// Interaction logic for View_Tasks_Page.xaml
    /// </summary>
    public partial class View_Tasks_Page : Page
    {
        private TaskMEntities context = new TaskMEntities();
        
        public View_Tasks_Page()
        {
            InitializeComponent();
            
            
        }

        private void load()
        {
            Datagridinprogress.ItemsSource = context.Tasks.ToList().Where(u => u.Status == "In Progress" || u.Status == "Pending");
            Datagridcomplete.ItemsSource = context.Tasks.ToList().Where(u => u.Status == "Completed");
            
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TXTtaskID.Text, out int id))
            {
                var date = context.Tasks.FirstOrDefault(u => u.TaskID == id);
                if (string.IsNullOrEmpty(combo.Text))
                {
                    MessageBox.Show("All Feilds are requerd",
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (date != null)
                {
                    
                    
                    date.Status = combo.Text;
                    load();
                    context.SaveChanges();
                    MessageBox.Show("Updated correctly!",
                        "Greate",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Add valid ID!",
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
    }
}
