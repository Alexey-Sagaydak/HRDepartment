using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HRDepartment
{
    /// <summary>
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"Resources\DBConnectionString.txt";
            try
            {
                Process.Start("notepad.exe", filePath);
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл со строкой подключения к БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedComboBoxItem = (ComboBoxItem)LanguageComboBox.SelectedItem;

            if (selectedComboBoxItem != null)
            {
                object tagValue = selectedComboBoxItem.Tag;

                if (tagValue != null)
                {
                    string tagAsString = tagValue.ToString();

                    WriteTextToFile(@"Resources\Language.txt", tagAsString);
                    MessageBox.Show("Изменение языка вступит в силе после перезапуска приложения", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public static void WriteTextToFile(string filePath, string textToWrite)
        {
            try
            {
                File.WriteAllText(filePath, textToWrite);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
