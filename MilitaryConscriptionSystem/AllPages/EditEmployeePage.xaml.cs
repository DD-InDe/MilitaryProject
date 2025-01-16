using System.Windows;
using System.Windows.Controls;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class EditEmployeePage : Page
{
    private Employee _employee;

    public EditEmployeePage()
    {
        _employee = new()
        {
            Passport = new() { IssuedDate = DateOnly.FromDateTime(DateTime.Today) },
            BirthDate = DateOnly.FromDateTime(DateTime.Today)
        };
        InitializeComponent();
    }

    public EditEmployeePage(Employee employee)
    {
        _employee = employee;
        InitializeComponent();
        if (_employee.PositionId == 5) PositionComboBox.IsEnabled = false;
    }

    private void EmployeeEditPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            PositionComboBox.ItemsSource = Db.Context.Positions.ToList();
            DataContext = _employee;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(_employee.FirstName) &&
                !String.IsNullOrEmpty(_employee.LastName) &&
                _employee.BirthDate != null &&
                _employee.Position != null &&
                _employee.Passport.Serial.ToString().Length == 4 &&
                _employee.Passport.Number.ToString().Length == 6 &&
                _employee.Passport.IssuedDate != null &&
                !String.IsNullOrEmpty(_employee.Passport.IssuedBy))
            {
                if (_employee.PassportId == 0)
                {
                    Db.Context.Passports.Add(_employee.Passport);
                    Db.Context.Employees.Add(_employee);
                }
                else
                {
                    Db.Context.Passports.Update(_employee.Passport);
                    Db.Context.Employees.Update(_employee);
                }

                Db.Context.SaveChanges();
                MessageBox.Show("Данные сохранены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
                MessageBox.Show("Заполните все поля! Номер и серия паспорта должны быть указаны в правильном формате.",
                    "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}