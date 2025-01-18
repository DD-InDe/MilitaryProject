using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class AddConsCommissionPage : Page
{
    private List<EmployeeCheck> _checks;

    public AddConsCommissionPage()
    {
        InitializeComponent();

        _checks = new();
        foreach (var employee in Db.Context.Employees.Include(c => c.Position).Where(c => c.PositionId != 5).ToList())
            _checks.Add(new(employee));

        EmployeeCheckListView.ItemsSource = _checks;
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (StartDatePicker.SelectedDate != null && EndDatePicker.SelectedDate != null &&
                _checks.Any(c => c.IsChecked))
            {
                List<Employee> selected = _checks.Where(c => c.IsChecked).Select(c => c.Employee).ToList();
                if (selected.Any(c => c.PositionId == 1) &&
                    selected.Any(c => c.PositionId == 2) &&
                    selected.Any(c => c.PositionId == 3) &&
                    selected.Any(c => c.PositionId == 4))
                {
                    ConscriptionCommission commission = new()
                    {
                        CreateDate = DateOnly.FromDateTime(StartDatePicker.SelectedDate.Value),
                        WorksUntilDate = DateOnly.FromDateTime(EndDatePicker.SelectedDate.Value)
                    };
                    List<ConscriptionCommissionEmployee> commissionEmployees = new();

                    foreach (var employee in selected)
                    {
                        commissionEmployees.Add(new()
                        {
                            EmployeeId = employee.PassportId,
                            ConscriptionCommission = commission
                        });
                    }

                    Db.Context.ConscriptionCommissions.Add(commission);
                    Db.Context.ConscriptionCommissionEmployees.AddRange(commissionEmployees);

                    Db.Context.SaveChanges();
                    MessageBox.Show("Данные добавлены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    NavigationService.GoBack();
                }
                else
                    MessageBox.Show("В комиссии должен быть минимум 1 сотрудник каждой должности!", "Сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ShowButton_OnClick(object sender, RoutedEventArgs e)
    {
        Popup.IsOpen = true;
    }

    private void CheckBox_StateChanged(object sender, RoutedEventArgs e)
    {
        try
        {
            List<string> selected = _checks.Where(c => c.IsChecked)
                .Select(c => c.Employee.ComboBoxField).ToList();

            if (selected.Count != 0)
            {
                string text = String.Empty;
                foreach (var se in selected)
                    text += se + ", ";

                EmployeesTextBox.Text = text.Substring(0, text.Length - 2);
            }
            else
                EmployeesTextBox.Text = string.Empty;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}