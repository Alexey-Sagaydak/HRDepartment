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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRDepartment
{
    /// <summary>
    /// Логика взаимодействия для ImposedPenaltiesPage.xaml
    /// </summary>
    public partial class ImposedPenaltiesPage : Page
    {
        private MainView parentWindow;
        private string title;

        public ImposedPenaltiesPage(string title, MainView parentWindow)
        {
            InitializeComponent();
            this.title = title;
            this.parentWindow = parentWindow;
            textBlock.Text = title;
        }

        private void ClosePage_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.RemoveOpenedPage(title);
        }
    }
}
