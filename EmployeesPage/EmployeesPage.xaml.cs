﻿using CommonClasses;
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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public IAccessRights accessRights;

        public EmployeesPage()
        {
            InitializeComponent();
            accessRights = DataStore.AccessRightsData;
            DataContext = new EmployeesViewModel(accessRights);
            ((EmployeesViewModel)DataContext).NewEmployeeAdded += AddNewEmployee;

            //var dbContext = new DBContext(); // Создайте экземпляр вашего DBContext
            //var employeeRepository = new EmployeeRepository(dbContext);

            //long employeeId = 1; // Замените на ID сотрудника, которого вы хотите получить
            //var employee = employeeRepository.GetEmployeeById(employeeId);
        }

        private void AddNewEmployee(Employee employee)
        {
            EditEmployeeInfo editEmployeeInfoPage = new EditEmployeeInfo(employee, accessRights);
            NavigationService.Navigate(editEmployeeInfoPage);
        }
    }
}
