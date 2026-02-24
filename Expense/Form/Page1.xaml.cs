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

namespace Form
{

    public class Person
    {
        public Person()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
    }
   
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Person person = new Person() 
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "Exmple@gmail.com",
                Address = "123 Main",
                Number = "123456789",

            };

            this.DataContext = person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = this.DataContext as Person;
            MessageBox.Show($"{person.FirstName}");
        }
    }
}
