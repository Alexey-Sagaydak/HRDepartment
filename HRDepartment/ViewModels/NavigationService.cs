using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HRDepartment
{
    public class NavigationService : INavigationService
    {
        private Window currentWindow;

        public NavigationService(Window window)
        {
            currentWindow = window;
        }

        public void OpenMainWindow(int userId)
        {
            MainView mainWindow = new MainView(userId);
            mainWindow.Show();
        }

        public void CloseCurrentWindow()
        {
            currentWindow.Close();
        }
    }
}
