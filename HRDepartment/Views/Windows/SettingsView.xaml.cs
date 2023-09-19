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
            Console.WriteLine("Я НЕ РАБОТАЮ!!!!!!!!!!!!!!!!");
        }
    }
}
