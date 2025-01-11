using System.Windows;
using System.Windows.Controls;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class AddNotice : Page
{
    private MilitaryDraftNotice _notice;

    public AddNotice(Conscript conscript)
    {
        _notice = new()
        {
            ConscriptId = conscript.PassportId
        };
        InitializeComponent();

        CommissionComboBox.ItemsSource = Db.Context.ConscriptionCommissions.ToList();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (DateTimePicker.Value != null && !String.IsNullOrEmpty(AddressTextBox.Text) &&
                CommissionComboBox.SelectedItem != null)
            {
                _notice.Address = AddressTextBox.Text;
                _notice.ConscriptionCommissionId =
                    ((ConscriptionCommission)CommissionComboBox.SelectedItem).ConscriptionCommissionId;

                Db.Context.MilitaryDraftNotices.Add(_notice);
                Db.Context.SaveChanges();

                MessageBox.Show("Данные сохранены!", "Сообщение", MessageBoxButton.OK,
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