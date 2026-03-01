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
    /// Interaction logic for User_Management_Page.xaml
    /// </summary>
    public partial class User_Management_Page : Page
    {
        private TaskMEntities context = new TaskMEntities();
        public User_Management_Page()
        {
            InitializeComponent();
            load();
            int id = int.Parse(TXTtaskID.Text);
            var employee = context.User1.FirstOrDefault(u => u.UserID == id);
            this.DataContext = employee;
        }

        

        private void load()
        {
            Datagrid.ItemsSource = context.Tasks.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(TXTtaskID.Text, out int id))
            {
                var data = new Task()
                {
                    TaskID = id,
                    Status = combo.Text,
                    Title = TXTtitle.Text,
                    Description = TXTDescreption.Text,
                    DueDate = TXTDate.SelectedDate,

                };

                context.Tasks.Add(data);
                context.SaveChanges();
                load();

                MessageBox.Show("Added!",
                    "Great",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TXTtaskID.Text, out int id))
            {
                var date = context.Tasks.FirstOrDefault(u => u.TaskID == id);
                if(string.IsNullOrEmpty(TXTtitle.Text) || string.IsNullOrEmpty(TXTDate.Text) || string.IsNullOrEmpty(TXTDescreption.Text) || string.IsNullOrEmpty(combo.Text))
                {
                    MessageBox.Show("All Feilds are requerd",
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (date != null)
                {
                    date.Title = TXTtitle.Text;
                    date.DueDate = TXTDate.SelectedDate;
                    date.Description = TXTDescreption.Text;
                    date.Status = combo.Text;
                    context.SaveChanges();
                    load();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TXTtaskID.Text, out int id))
            {
                if (string.IsNullOrEmpty(TXTtaskID.Text))
                {
                    MessageBox.Show("the id field is requerd!",
                        "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                var date = context.Tasks.FirstOrDefault(u => u.TaskID == id);
                if (date != null)
                {
                    


                   
                    MessageBoxResult result = MessageBox.Show("Are you want to delete it!",
                        "Waring",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    

                    if(result == MessageBoxResult.Yes)
                    {
                        context.Tasks.Remove(date);
                        context.SaveChanges();
                        load();
                    }
                    
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

        public class Employee
        {
            public string Name { get; set; }
        }
    }
}
