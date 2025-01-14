using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class ViewConsCommissionsPage : Page
{
    class ViewConscriptionCommission()
    {
        public ConscriptionCommission Commission { get; set; }
        public List<Employee> Employees { get; set; }
    }

    public ViewConsCommissionsPage()
    {
        InitializeComponent();
        LoadData();
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            string search = SearchTextBox.Text;

            List<ViewConscriptionCommission> commissions = new();
            foreach (var commission in Db.Context.ConscriptionCommissions.ToList())
            {
                commissions.Add(new()
                {
                    Commission = commission,
                    Employees = Db.Context.ConscriptionCommissionEmployees
                        .Include(c => c.Employee)
                        .Include(c => c.Employee.Position)
                        .Where(c => c.ConscriptionCommissionId == commission.ConscriptionCommissionId)
                        .Select(c => c.Employee).ToList()
                });
            }

            commissions = commissions.Where(c => c.Commission.CreateDate.Value.ToString().Contains(search) ||
                                                 c.Commission.WorksUntilDate.Value.ToString().Contains(search) ||
                                                 c.Employees.Any(e => e.FirstName.ToLower().Contains(search)) ||
                                                 c.Employees.Any(e => e.LastName.ToLower().Contains(search)))
                .ToList();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = commissions;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ProtocolButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ConscriptionCommission commission = ((ViewConscriptionCommission)((Button)sender).DataContext).Commission;

            OpenFileDialog dialog = new() { Filter = "documents | *.docx; *.doc;*.pdf" };
            if (dialog.ShowDialog() == true)
            {
                commission.Protocol = File.ReadAllBytes(dialog.FileName);
                Db.Context.SaveChanges();
                MessageBox.Show("Данные сохранены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                LoadData();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AddConsCommissionPage());
    }
}