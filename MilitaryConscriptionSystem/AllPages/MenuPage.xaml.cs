using System.Windows;
using System.Windows.Controls;

namespace MilitaryConscriptionSystem.AllPages;

public partial class MenuPage : Page
{
    public MenuPage()
    {
        InitializeComponent();
    }

    private void ConscriptButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ViewConscripts());
    }
}