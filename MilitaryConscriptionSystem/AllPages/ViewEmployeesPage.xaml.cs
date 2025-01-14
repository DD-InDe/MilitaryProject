using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class ViewEmployeesPage : Page
{
    public ViewEmployeesPage()
    {
        InitializeComponent();

        List<Position> positions = new() { new() { Name = "Все" } };
        positions.AddRange(Db.Context.Positions.ToList());
        PositionComboBox.ItemsSource = positions;

        LoadData();
    }

    private void LoadData()
    {
        try
        {
            string search = SearchTextBox.Text.ToLower();
            Position? position = (Position)PositionComboBox.SelectedItem;

            List<Employee> employees =
                Db.Context.Employees
                    .Include(c => c.Passport)
                    .Include(c => c.Position)
                    .Where(c =>
                        c.FirstName.ToLower().Contains(search) ||
                        c.LastName.ToLower().Contains(search) ||
                        (c.MiddleName != null && c.MiddleName.ToLower().Contains(search)))
                    .ToList();

            if (position != null && position.PositionId != 0)
                employees = employees.Where(c => c.PositionId == position.PositionId).ToList();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = employees;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new EmployeeEditPage());
    }

    private void ViewInfoButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Employee? employee = DataGrid.SelectedItem as Employee;
            if (employee != null)
            {
                if (employee.PositionId != 6)
                    NavigationService.Navigate(new EmployeeEditPage(employee));
                else
                    MessageBox.Show("Нельзя редактировать администратора", "Сообщение", MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите сначала сотрудника из таблицы", "Сообщение", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void PositionComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LoadData();
    }
}