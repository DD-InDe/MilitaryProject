using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class AddNoticePage : Page
{
    private MilitaryDraftNotice _notice;
    private List<ConscriptCheck> _checks;

    public AddNoticePage()
    {
        _notice = new();
        InitializeComponent();

        List<string> times = new();
        TimeOnly start = new(8, 0);
        TimeOnly end = new(17, 15);
        while (start < end)
        {
            times.Add(start.ToString("t"));
            start = start.AddMinutes(15);
        }

        _checks = new();
        foreach (var conscript in Db.Context.Conscripts.ToList())
            _checks.Add(new(conscript));

        ConscriptsCheckListView.ItemsSource = _checks;
        TimeComboBox.ItemsSource = times;
        CommissionComboBox.ItemsSource = Db.Context.ConscriptionCommissions.ToList();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (TimeComboBox.SelectedItem != null && !String.IsNullOrEmpty(AddressTextBox.Text) &&
                CommissionComboBox.SelectedItem != null && _checks.Any(c=>c.IsChecked))
            {
                string[] time = ((String)TimeComboBox.SelectedItem).Split(":");

                foreach (var item in _checks.Where(c=>c.IsChecked).ToList())
                {
                    _notice = new()
                    {
                        Date = DateOnly.FromDateTime(DatePicker.SelectedDate.Value),
                        Time = new TimeOnly(int.Parse(time[0]), int.Parse(time[1])),
                        Address = AddressTextBox.Text,
                        ConscriptionCommissionId = ((ConscriptionCommission)CommissionComboBox.SelectedItem)
                            .ConscriptionCommissionId,
                        ConscriptId = item.Conscript.PassportId
                    };

                    Db.Context.MilitaryDraftNotices.Add(_notice);
                }

                Db.Context.SaveChanges();

                MessageBox.Show("Данные сохранены!", "Сообщение", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                NavigationService.GoBack();
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

    private void CheckBox_StateChanged(object sender, RoutedEventArgs e)
    {
        try
        {
            List<string> selected = _checks.Where(c => c.IsChecked)
                .Select(c => c.Conscript.FullName).ToList();

            if (selected.Count != 0)
            {
                string text = String.Empty;
                foreach (var se in selected)
                    text += se + ", ";

                ConscriptsTextBox.Text = text.Substring(0, text.Length - 2);
            }
            else
                ConscriptsTextBox.Text = string.Empty;
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
}