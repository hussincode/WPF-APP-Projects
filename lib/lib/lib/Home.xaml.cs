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

namespace lib
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private LibraryDBEntities context;
        private void Window(object sender, RoutedEventArgs e)
        {
            load();
        }
        public Home()
        {
            InitializeComponent();
        }
        private void load()
        {
            var context = new LibraryDBEntities();
            UsersDataGrid.ItemsSource = context.Books.ToList();
        }
        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                IdTextBox.Text = selectedUser.Id.ToString();
                NameTextBox.Text = selectedUser.FullName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IdTextBox.Text, out int id))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user.FullName = NameTextBox.Text;
                    context.SaveChanges();
                    MessageBox.Show("Updated successfully!");
                    load();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IdTextBox.Text, out int id))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    MessageBox.Show("Deleted successfully!");
                    load();
                    IdTextBox.Clear();
                    NameTextBox.Clear();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string filterValue = FilterTextBox.Text.Trim();
            if (FilterComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string filterBy = selectedItem.Content.ToString();
                IQueryable<Book> query = context.Books;

                if (!string.IsNullOrEmpty(filterValue))
                {
                    switch (filterBy)
                    {
                        case "Author":
                            query = query.Where(u => u.Author.Contains(filterValue));
                            break;
                        case "Category":
                            query = query.Where(u => u.Category.Contains(filterValue));
                            break;
                        case "Title":
                            query = query.Where(u => u.Title.Contains(filterValue));
                            break;
                    }
                }

                UsersDataGrid.ItemsSource = query.ToList();
            }
        }

       
    }
}
