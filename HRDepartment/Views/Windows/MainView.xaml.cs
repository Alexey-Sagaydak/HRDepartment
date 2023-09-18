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
        private List<OpenedPage> openedPages = new List<OpenedPage>();

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

        private void AddOpenedPage(string title, Page page)
        {
            var openedPage = new OpenedPage(title, page);
            openedPages.Add(openedPage);

            MenuItem menuItem = new MenuItem();

            menuItem.Header = title;
            menuItem.Tag = openedPage;
            menuItem.Click += WindowMenuItem_Click;
            windowsMenuItem.Items.Add(menuItem);

            mainFrame.NavigationService.Navigate(page);
        }

        public void RemoveOpenedPage(string title)
        {
            foreach (var openPage in  openedPages)
            {
                if (openPage.Title == title)
                {
                    openedPages.Remove(openPage);
                    break;
                }
            }

            foreach (var menuItem in windowsMenuItem.Items.OfType<MenuItem>())
            {
                if (menuItem.Header.ToString() == title)
                {
                    windowsMenuItem.Items.Remove(menuItem);
                    mainFrame.Content = null;

                    if (openedPages.Count > 0)
                        mainFrame.NavigationService.Navigate(openedPages[openedPages.Count - 1].PageInstance);
                    break;
                }
            }
        }

        private void WindowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.Tag is OpenedPage openedPage)
            {
                mainFrame.NavigationService.Navigate(openedPage.PageInstance);
            }
        }

        private string AddNumberToPageString(string str)
        {
            return $"{openedPages.Count + 1}. {str}";
        }

        private void OpenImposedPenaltiesPage(object sender, RoutedEventArgs e)
        {
            string title = AddNumberToPageString("Наложенные взыскания");

            Page page = new ImposedPenaltiesPage(title, this);
            AddOpenedPage(title, page);
        }

        private void OpenEncouragementsPage(object sender, RoutedEventArgs e)
        {
            string title = AddNumberToPageString("Поощрения");
            Page page = new EncouragementsPage(title, this);
            AddOpenedPage(title, page);
        }
    }
}
