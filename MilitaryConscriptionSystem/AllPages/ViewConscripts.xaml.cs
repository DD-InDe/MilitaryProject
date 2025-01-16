using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class ViewConscripts : Page
{
    public ViewConscripts()
    {
        InitializeComponent();
        LoadData();
        if (App.Employee.PositionId == 5) CreateNoticeButton.Visibility = Visibility.Visible;
    }

    private void LoadData()
    {
        try
        {
            string search = SearchTextBox.Text.ToLower();

            List<Conscript> conscripts =
                Db.Context.Conscripts
                    .Include(c => c.Passport)
                    .Where(c =>
                        c.FirstName.ToLower().Contains(search) ||
                        c.LastName.ToLower().Contains(search) ||
                        (c.MiddleName != null && c.MiddleName.ToLower().Contains(search)))
                    .ToList();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = conscripts;
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
        NavigationService.Navigate(new EditConscriptPage());
    }

    private void ViewInfoButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Conscript? conscript = DataGrid.SelectedItem as Conscript;
            if (conscript != null)
            {
                NavigationService.Navigate(new EditConscriptPage(conscript));
            }
            else
            {
                MessageBox.Show("Выберите сначала призывника из таблицы", "Сообщение", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CreateNoticeButton_OnClick(object sender, RoutedEventArgs e)
    {
        Conscript? conscript = DataGrid.SelectedItem as Conscript;
        if (conscript != null)
        {
            NavigationService.Navigate(new AddNoticePage(conscript));
        }
        else
        {
            MessageBox.Show("Выберите сначала призывника из таблицы", "Сообщение", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}