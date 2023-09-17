using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для MainView
    /// </summary>
    public partial class MainView : Window
    {
        private int currentEmployeeId;
        public MainView(int id)
        {
            InitializeComponent();
            currentEmployeeId = id;
            Title = $"АИС Отдел кадров. Сотрудник id: {id}";
        }

        private void AboutMenuItemClick(object sender, RoutedEventArgs e)
        {
            AboutView aboutView = new AboutView();
            aboutView.ShowDialog();
        }

        private void ContentMenuItemClick(object sender, RoutedEventArgs e)
        {
            ContentView contentView = new ContentView();
            contentView.ShowDialog();
        }

        private void ChangePasswordMenuItemClick(object sender, RoutedEventArgs e)
        {
            ChangePasswordView changePasswordView = new ChangePasswordView(currentEmployeeId);
            changePasswordView.ShowDialog();
        }

        private void ExitMenuItemClick(object sender, RoutedEventArgs e)
        {
            LogInView logInView = new LogInView();
            logInView.Show();
            Close();
        }
    }
}
