﻿using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MilitaryConscriptionSystem.Database;

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

            List<MilitaryDraftNotice> notices = Db.Context.MilitaryDraftNotices
                .Include(c => c.Conscript)
                .Include(c => c.Conscript.Passport)
                .Where(c => c.Conscript.FirstName.ToLower().Contains(search) ||
                            c.Conscript.LastName.ToLower().Contains(search) ||
                            (c.Conscript.MiddleName != null && c.Conscript.MiddleName.ToLower().Contains(search)))
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
}