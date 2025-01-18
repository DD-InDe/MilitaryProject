using System.Windows;
using System.Windows.Controls;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class AddNoticePage : Page
{
    private MilitaryDraftNotice _notice;

    public AddNoticePage(Conscript conscript)
    {
        _notice = new()
        {
            ConscriptId = conscript.PassportId
        };
        InitializeComponent();

        List<string> times = new();
        TimeOnly start = new(8, 0);
        TimeOnly end = new(17, 15);
        while (start < end)
        {
            times.Add(start.ToString("t"));
            start = start.AddMinutes(15);
        }

        TimeComboBox.ItemsSource = times;
        CommissionComboBox.ItemsSource = Db.Context.ConscriptionCommissions.ToList();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (TimeComboBox.SelectedItem != null && !String.IsNullOrEmpty(AddressTextBox.Text) &&
                CommissionComboBox.SelectedItem != null)
            {
                string[] time = ((String)TimeComboBox.SelectedItem).Split(":");
                
                _notice.Date = DateOnly.FromDateTime(DatePicker.SelectedDate.Value);
                _notice.Time = new TimeOnly(int.Parse(time[0]),int.Parse(time[1]));
                _notice.Address = AddressTextBox.Text;
                _notice.ConscriptionCommissionId =
                    ((ConscriptionCommission)CommissionComboBox.SelectedItem).ConscriptionCommissionId;

                Db.Context.MilitaryDraftNotices.Add(_notice);
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
}