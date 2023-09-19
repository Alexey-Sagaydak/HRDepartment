using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
            ComboBoxItem selectedItem = (ComboBoxItem)LanguageComboBox.SelectedItem;
            if (selectedItem != null)
            {
                string selectedCulture = selectedItem.Tag.ToString();

                // Устанавливаем выбранную локализацию для всего приложения.
                CultureInfo newCulture = new CultureInfo(selectedCulture);
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;

                // Обновляем ресурсы локализации для всех элементов интерфейса.
                ResourceDictionary dict = new ResourceDictionary();
                dict.Source = new Uri($"/HRDepartment;component/Resources/Localization-{selectedCulture}.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }
    }
}
