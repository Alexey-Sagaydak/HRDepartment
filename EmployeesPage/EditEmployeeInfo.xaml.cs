using CommonClasses;
using EmployeesPage;
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

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для EditEmployeeInfo.xaml
    /// </summary>
    public partial class EditEmployeeInfo : Page
    {
        public EditEmployeeInfo(Employee employee)
        {
            InitializeComponent();
            DataContext = new EditEmployeeInfoViewModel(employee);
        }

        private void specialtyComboBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string inputText = comboBox.Text;

            if (!((EditEmployeeInfoViewModel)DataContext).Specialties.Any(s => s.Name.Equals(inputText, StringComparison.OrdinalIgnoreCase)))
            {
                specialtyComboBox.Background = Brushes.IndianRed;
            }
            else
            {
                specialtyComboBox.Background = Brushes.Transparent;
            }
        }

        private void eduInstitutionsComboBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string inputText = comboBox.Text;

            if (!((EditEmployeeInfoViewModel)DataContext).EduInstitutions.Any(s => s.Name.Equals(inputText, StringComparison.OrdinalIgnoreCase)))
            {
                eduInstitutionsComboBox.Background = Brushes.IndianRed;
            }
            else
            {
                eduInstitutionsComboBox.Background = Brushes.Transparent;
            }
        }
    }
}
