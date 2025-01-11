using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MilitaryConscriptionSystem.Database;

namespace MilitaryConscriptionSystem.AllPages;

public partial class ConscriptEditPage : Page
{
    private ConscriptDocument? _document;
    private Conscript _conscript;
    private List<ConscriptDocument> _documents = new();

    public ConscriptEditPage()
    {
        InitializeComponent();
        _conscript = new() { Passport = new() };
    }

    public ConscriptEditPage(Conscript conscript)
    {
        InitializeComponent();
        _conscript = conscript;
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(_conscript.FirstName) &&
                !String.IsNullOrEmpty(_conscript.LastName) &&
                _conscript is { BirthDate: not null, RegistrationDate: not null } &&
                _conscript.Passport.Serial.ToString().Length == 4 &&
                _conscript.Passport.Number.ToString().Length == 6 &&
                _conscript.Passport.IssuedDate != null &&
                !String.IsNullOrEmpty(_conscript.Passport.IssuedBy))
            {
                if (_conscript.PassportId == 0)
                {
                    Db.Context.Passports.Add(_conscript.Passport);
                    Db.Context.Conscripts.Add(_conscript);
                }
                else
                {
                    Db.Context.Passports.Update(_conscript.Passport);
                    Db.Context.Conscripts.Update(_conscript);
                }

                Db.Context.SaveChanges();
                MessageBox.Show("Данные сохранены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
                MessageBox.Show("Заполните все поля! Номер и серия паспорта должны быть указаны в правильном формате.",
                    "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void LoadFiles()
    {
        try
        {
            _documents.Clear();
            _documents.AddRange(Db.Context.ConscriptDocuments.Where(c => c.ConscriptId == _conscript.PassportId));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SaveFileButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ConscriptEditPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            DataPanel.DataContext = _conscript;
            LoadFiles();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void LoadFile_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog dialog = new() { Filter = "documents | *.docx; *.doc;*.pdf" };
            if (dialog.ShowDialog() == true)
            {
                _document = new()
                    { DocumentFile = File.ReadAllBytes(dialog.FileName), DocumentName = dialog.SafeFileName };
                
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}