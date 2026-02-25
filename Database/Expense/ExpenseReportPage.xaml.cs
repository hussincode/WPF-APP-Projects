using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace Expense
{
    /// <summary>
    /// Interaction logic for ExpenseReportPage.xaml
    /// </summary>
    public partial class ExpenseReportPage : Page
    {
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            load();
        }
        public ExpenseReportPage()
        {
            InitializeComponent();
        }
        //loading data when window is loaded
        

        //reading data from database and showing in datagrid
        private void load()
        {
            using (var context = new ExpenseEntities())
            {
                var data = context.expense_report.ToList();
                dataGrid.ItemsSource = data;
            }
        }

        private void Clearfield()
        {
            nameTextBlock.Text = "";
            AmountTextBlock.Text = "";
            DepartmentTextBlock.Text = "";
            ExpenseTitleTextBlock.Text = "";
            NotesTextBlock.Text = "";
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new ExpenseEntities())
            {
                var report = new expense_report
                {   
                    Name = nameTextBlock.Text,
                    Amount = decimal.Parse(AmountTextBlock.Text),
                    ExpenseDate = DateTime.Now,
                    Department = DepartmentTextBlock.Text,
                    ExpenseTitle = ExpenseTitleTextBlock.Text,
                    Notes = NotesTextBlock.Text,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };
                context.expense_report.Add(report);
                context.SaveChanges();
            }

            Clearfield();
            load();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            expense_report selectedReport = (expense_report)dataGrid.SelectedItem;
            using (var context = new ExpenseEntities())
            {
                expense_report expense_Report = context.expense_report.Find(selectedReport.Id);
                if(expense_Report != null)
                {
                    expense_Report.Name= nameTextBlock.Text;
                    expense_Report.Amount = decimal.Parse(AmountTextBlock.Text);
                    expense_Report.Notes = NotesTextBlock.Text;
                    expense_Report.ExpenseDate = DateTime.Now;
                    expense_Report.Department = DepartmentTextBlock.Text;
                    expense_Report.ExpenseTitle = ExpenseTitleTextBlock.Text;
                    expense_Report.Notes = NotesTextBlock.Text;
                    expense_Report.CreatedAt = DateTime.Now;
                    expense_Report.IsActive = true;
                    context.expense_report.AddOrUpdate(expense_Report);
                    context.SaveChanges();
                }
            }
            load();
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            expense_report selectedReport = (expense_report)dataGrid.SelectedItem;
            using (var context = new ExpenseEntities())
            {
                expense_report expense_Report = context.expense_report.Find(selectedReport.Id);
                if (expense_Report != null)
                {
                    expense_Report.Name = nameTextBlock.Text;
                    expense_Report.Amount = decimal.Parse(AmountTextBlock.Text);
                    expense_Report.Notes = NotesTextBlock.Text;
                    expense_Report.ExpenseDate = DateTime.Now;
                    expense_Report.Department = DepartmentTextBlock.Text;
                    expense_Report.ExpenseTitle = ExpenseTitleTextBlock.Text;
                    expense_Report.Notes = NotesTextBlock.Text;
                    expense_Report.CreatedAt = DateTime.Now;
                    expense_Report.IsActive = true;
                    context.expense_report.Remove(expense_Report);
                    context.SaveChanges();
                }
            }
            load();
        }
    }
}
