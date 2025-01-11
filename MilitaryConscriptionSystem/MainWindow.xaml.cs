using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MilitaryConscriptionSystem.AllPages;

namespace MilitaryConscriptionSystem;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Frame_OnNavigated(object sender, NavigationEventArgs e)
    {
        try
        {
            if (Frame.CanGoBack)
            {
                if (Frame.Content.GetType() == typeof(MenuPage))
                {
                    BackButton.Visibility = Visibility.Collapsed;
                    ExitButton.Visibility = Visibility.Visible;
                }
                else if (Frame.CanGoBack)
                {
                    BackButton.Visibility = Visibility.Visible;
                    ExitButton.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                BackButton.Visibility = Visibility.Collapsed;
                ExitButton.Visibility = Visibility.Collapsed;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => Frame.GoBack();

    private void ExitButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            App.Employee = null;
            Frame.GoBack();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}