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

namespace Demo1
{
    /// <summary>
    /// Interaction logic for Home_Window.xaml
    /// </summary>
    public partial class Home_Window : Page
    {
        public Home_Window()
        {
            InitializeComponent();
        }

        private void DockPanel_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Quiz quiz = new Quiz();
            this.NavigationService.Navigate(quiz);
        }
    }
}
