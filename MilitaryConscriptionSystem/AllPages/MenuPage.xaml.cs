using System.Windows;
using System.Windows.Controls;

namespace MilitaryConscriptionSystem.AllPages;

public partial class MenuPage : Page
{
    public MenuPage()
    {
        InitializeComponent();
        if (App.Employee.PositionId == 5)
        {
            EmployeeButton.Visibility = Visibility.Visible;
            CommissionButton.Visibility = Visibility.Visible;
        }
    }

    private void ConscriptButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ViewConscriptsPage());
    }

    private void EmployeeButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ViewEmployeesPage());
    }

    private void CommissionButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ViewConsCommissionsPage());
    }

    private void NoticesButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ViewNoticesPage());
    }
}