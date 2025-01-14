using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class AddConsCommissionPage : Page
{
    public AddConsCommissionPage()
    {
        InitializeComponent();
        EmployeeCheckComboBox.ItemsSource =
            Db.Context.Employees.Include(c => c.Position).Where(c => c.PositionId != 5).ToList();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (StartDatePicker.SelectedDate != null && EndDatePicker.SelectedDate != null &&
                EmployeeCheckComboBox.SelectedItems.Count > 0)
            {
                List<Employee> selected = EmployeeCheckComboBox.SelectedItems.Cast<Employee>().ToList();
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
}