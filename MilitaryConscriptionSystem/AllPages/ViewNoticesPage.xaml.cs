using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MilitaryConscriptionSystem.Database;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace MilitaryConscriptionSystem.AllPages;

public partial class ViewNoticesPage : Page
{
    public ViewNoticesPage()
    {
        InitializeComponent();
        LoadData();
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            string search = SearchTextBox.Text.ToLower();

            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;

            List<MilitaryDraftNotice> notices = Db.Context.MilitaryDraftNotices
                .Include(c => c.Conscript)
                .Include(c => c.Conscript.Passport)
                .Where(c => (c.Conscript.FirstName.ToLower().Contains(search) ||
                             c.Conscript.LastName.ToLower().Contains(search) ||
                             (c.Conscript.MiddleName != null && c.Conscript.MiddleName.ToLower().Contains(search))))
                .ToList();

            notices = notices.Where(c =>
                    ((startDate != null && c.Date.Value >= DateOnly.FromDateTime(startDate.Value)) ||
                     startDate == null) &&
                    ((endDate != null && c.Date.Value <= DateOnly.FromDateTime(endDate.Value)) || endDate == null))
                .ToList();

            if (App.Employee.PositionId != 5)
            {
                List<ConscriptionCommission> commissions = Db.Context.ConscriptionCommissionEmployees
                    .Where(c => c.EmployeeId == App.Employee.PassportId).Select(c => c.ConscriptionCommission).ToList();

                notices = notices.Where(c =>
                        commissions.Any(a => a.ConscriptionCommissionId == c.ConscriptionCommissionId))
                    .ToList();
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = notices;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void InfoButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new NoticeInfoPage(((Button)sender).DataContext as MilitaryDraftNotice));
    }

    private void DatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        LoadData();
    }

    private void ResetButton_OnClick(object sender, RoutedEventArgs e)
    {
        SearchTextBox.Text = String.Empty;
        StartDatePicker.SelectedDate = null;
        EndDatePicker.SelectedDate = null;
    }

    private void DocumentButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            MilitaryDraftNotice notice = ((Button)sender).DataContext as MilitaryDraftNotice;

            Document document = DocX.Load("шаблон.docx");
            string conscriptFullName =
                $"{notice.Conscript.LastName} {notice.Conscript.FirstName} {notice.Conscript.MiddleName}";
            string commissarFullName =
                $"{App.Employee.LastName} {App.Employee.FirstName} {App.Employee.MiddleName}";
            document.ReplaceText("<<гражданин>>", conscriptFullName);
            document.ReplaceText("<<номер>>", notice.MilitaryDraftNoticeId.ToString());
            document.ReplaceText("<<день>>", notice.Date.Value.Day.ToString());
            document.ReplaceText("<<месяц>>", GetMonthName(notice.Date.Value.Month));
            document.ReplaceText("<<год>>", notice.Date.Value.Year.ToString());
            document.ReplaceText("<<час>>", notice.Time.Value.Hour.ToString());
            document.ReplaceText("<<адрес>>", notice.Address);
            document.ReplaceText("<<фио комиссара>>", commissarFullName);
            
            document.SaveAs($"Повестка_#{notice.MilitaryDraftNoticeId}_{notice.Conscript.LastName}.docx");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private string GetMonthName(int month)
    {
        return month switch
        {
            1 => "Января",
            2 => "Февраля",
            3 => "Марта",
            4 => "Апреля",
            5 => "Мая",
            6 => "Июня",
            7 => "Июля",
            8 => "Августа",
            9 => "Сентября",
            10 => "Октября",
            11 => "Ноября",
            12 => "Декабря",
            _ => ""
        };
    }
}