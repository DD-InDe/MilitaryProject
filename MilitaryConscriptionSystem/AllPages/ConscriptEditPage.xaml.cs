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

    public ConscriptEditPage()
    {
        _conscript = new()
        {
            Passport = new() { IssuedDate = DateOnly.FromDateTime(DateTime.Now) },
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
        };
        InitializeComponent();
    }

    public ConscriptEditPage(Conscript conscript)
    {
        if (conscript.Passport == null)
            conscript.Passport = Db.Context.Passports.Find(conscript.PassportId);

        _conscript = conscript;
        InitializeComponent();
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
            FileListView.ItemsSource = null;
            FileListView.ItemsSource = Db.Context.ConscriptDocuments.Where(c => c.ConscriptId == _conscript.PassportId)
                .ToList();
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
            if (_conscript.PassportId != 0)
            {
                _document.Description = DescriptionTextBox.Text;
                _document.ConscriptId = _conscript.PassportId;
                Db.Context.ConscriptDocuments.Add(_document);
                Db.Context.SaveChanges();

                _document = new();
                SaveFileButton.Visibility = Visibility.Collapsed;
                DescriptionTextBox.Text = String.Empty;
                LoadFiles();
                MessageBox.Show("Файл добавлен!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
                MessageBox.Show("Призывник еще не добавлен!", "Сообщение", MessageBoxButton.OK,
                    MessageBoxImage.Information);
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
                SaveFileButton.Visibility = Visibility.Visible;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ConscriptDocument document = ((Button)sender).DataContext as ConscriptDocument;
            Db.Context.ConscriptDocuments.Remove(document);
            Db.Context.SaveChanges();

            MessageBox.Show("Файл удален!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            LoadFiles();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}