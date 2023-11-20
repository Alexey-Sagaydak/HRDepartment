using CommonClasses;
using EmployeesPage;
using MaterialDesignThemes.Wpf;
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

        private void EduDocumentTypesComboBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string inputText = comboBox.Text;

            if (!((EditEmployeeInfoViewModel)DataContext).EduDocumentTypes.Any(s => s.Name.Equals(inputText, StringComparison.OrdinalIgnoreCase)))
            {
                eduDocumentTypesComboBox.Background = Brushes.IndianRed;
            }
            else
            {
                eduDocumentTypesComboBox.Background = Brushes.Transparent;
            }
        }

        private void divisionsComboBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string inputText = comboBox.Text;

            if (!((EditEmployeeInfoViewModel)DataContext).Divisions.Any(s => s.Name.Equals(inputText, StringComparison.OrdinalIgnoreCase)))
            {
                divisionsComboBox.Background = Brushes.IndianRed;
            }
            else
            {
                divisionsComboBox.Background = Brushes.Transparent;
            }
        }

        private void positionsComboBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string inputText = comboBox.Text;

            if (!((EditEmployeeInfoViewModel)DataContext).Positions.Any(s => s.Name.Equals(inputText, StringComparison.OrdinalIgnoreCase)))
            {
                positionsComboBox.Background = Brushes.IndianRed;
            }
            else
            {
                positionsComboBox.Background = Brushes.Transparent;
            }
        }

        private void organizationNamesComboBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string inputText = comboBox.Text;

            if (!((EditEmployeeInfoViewModel)DataContext).OrganizationNames.Any(s => s.Name.Equals(inputText, StringComparison.OrdinalIgnoreCase)))
            {
                organizationNamesComboBox.Background = Brushes.IndianRed;
            }
            else
            {
                organizationNamesComboBox.Background = Brushes.Transparent;
            }
        }
    }
}
