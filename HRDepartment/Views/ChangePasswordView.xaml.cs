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
    /// Логика взаимодействия для ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : Window
    {
        public ChangePasswordView(int id)
        {
            InitializeComponent();
            DataContext = new ChangePasswordViewModel(id);
        }

        private void Password1Changed(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((ChangePasswordViewModel)DataContext).NewPassword1 = PasswordBox1.Password;
            }
        }

        private void Password2Changed(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((ChangePasswordViewModel)DataContext).NewPassword2 = PasswordBox2.Password;
            }
        }
    }
}
