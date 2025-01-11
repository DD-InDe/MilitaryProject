using System.Windows;
using System.Windows.Controls;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                Employee? employee =
                    Db.Context.Employees.FirstOrDefault(c => c.Login == login && c.Password == password);
                if (employee != null)
                {
                    App.Employee = employee;
                    NavigationService.Navigate(new MenuPage());
                }
                else
                    MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}