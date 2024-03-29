﻿using Microsoft.EntityFrameworkCore.Migrations;
using Orders;
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
using static HRDepartment.MainViewModel;
using CommonClasses;

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
            DataContext = new MainViewModel(currentEmployeeId);
            ((MainViewModel)DataContext).SomeEvent += OpenPage;
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

        private void AddOpenedPage(string title, IAccessRights accessRights, Type type)
        {
            DataStore.AccessRightsData = accessRights;
            Page page = (Page)Activator.CreateInstance(type);
            
            OpenedPage openedPage = new OpenedPage(title, page, accessRights);
            openedPages.Add(openedPage);

            MenuItem menuItem = new MenuItem();

            menuItem.Header = title;
            menuItem.Tag = openedPage;
            menuItem.Click += WindowMenuItem_Click;
            menuItem.Height = 22;
            windowsMenuItem.Items.Add(menuItem);

            mainFrame.NavigationService.Navigate(page, accessRights);
            mainFrame.Tag = openedPage;

            ChangeCloseButtonEnableStatus();
        }

        private void RemoveOpenedPage()
        {
            OpenedPage openedPage = mainFrame.Tag as OpenedPage;
            openedPages.Remove(openedPage);

            foreach (var menuItem in windowsMenuItem.Items.OfType<MenuItem>())
            {
                if (menuItem.Tag == openedPage)
                {
                    windowsMenuItem.Items.Remove(menuItem);
                    mainFrame.Content = null;
                    mainFrame.Tag = null;

                    if (openedPages.Count > 0)
                    {
                        mainFrame.NavigationService.Navigate(openedPages[openedPages.Count - 1].PageInstance);
                        mainFrame.Tag = openedPages[openedPages.Count - 1];
                    }
                    ChangeCloseButtonEnableStatus();
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

        private void OpenPage(string title, IAccessRights accessRights, Type type)
        {
            AddOpenedPage(AddNumberToPageString(title), accessRights, type);
        }

        private void RemoveOpenedPage_Click(object sender, RoutedEventArgs e)
        {
            RemoveOpenedPage();
        }

        private void ChangeCloseButtonEnableStatus()
        {
            closeButton.IsEnabled = mainFrame.Tag != null;
        }

        private void SettingsMenuItemClick(object sender, RoutedEventArgs e)
        {
            SettingsView settingsView = new SettingsView();
            settingsView.ShowDialog();
        }
    }
}
