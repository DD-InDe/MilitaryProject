using System.Windows;
using System.Windows.Controls;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class NoticeInfoPage : Page
{
    private MilitaryDraftNotice _notice;

    public NoticeInfoPage(MilitaryDraftNotice notice)
    {
        _notice = notice;
        InitializeComponent();
        CategoryComboBox.ItemsSource = Db.Context.Categories.ToList();
        ResultComboBox.ItemsSource = Db.Context.Results.ToList();

        MainInfoPanel.DataContext = _notice;
        ViewResultPanel.DataContext = _notice;
        AddResultPanel.DataContext = _notice;

        LoadData();
    }

    private void LoadData()
    {
        try
        {
            MedicalCommission? commission = Db.Context.MedicalCommissions.Find(_notice.MilitaryDraftNoticeId);

            if (commission == null)
            {
                if (App.Employee.PositionId == 4)
                    AddMedCommissionButton.Visibility = Visibility.Visible;
            }
            else if (_notice.Result == null)
            {
                ViewMedCommissionPanel.Visibility = Visibility.Visible;
                ViewMedCommissionPanel.DataContext = commission;
                AddResultPanel.Visibility = Visibility.Visible;
                SaveResultButton.Visibility = Visibility.Visible;
            }
            else
            {
                ViewMedCommissionPanel.Visibility = Visibility.Visible;
                ViewMedCommissionPanel.DataContext = commission;
                ViewResultPanel.Visibility = Visibility.Visible;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ConscriptButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ConscriptEditPage(_notice.Conscript));

    private void AddMedCommissionButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            AddMedCommissionButton.Visibility = Visibility.Collapsed;
            AddMedCommissionPanel.Visibility = Visibility.Visible;

            MedicalCommission commission = new() { MilitaryDraftNoticeId = _notice.MilitaryDraftNoticeId };
            AddMedCommissionPanel.DataContext = commission;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SaveMedButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            MedicalCommission commission = (MedicalCommission)AddMedCommissionPanel.DataContext;
            Db.Context.MedicalCommissions.Add(commission);
            Db.Context.SaveChanges();
            MessageBox.Show("Данные сохранены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            AddMedCommissionPanel.Visibility = Visibility.Collapsed;
            LoadData();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SaveResultButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Db.Context.MilitaryDraftNotices.Update(_notice);
            Db.Context.SaveChanges();
            MessageBox.Show("Данные сохранены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            SaveResultButton.Visibility = Visibility.Collapsed;
            AddResultPanel.Visibility = Visibility.Collapsed;
            ViewResultPanel.Visibility = Visibility.Visible;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}