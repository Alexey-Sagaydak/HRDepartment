using CommonClasses;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class EmployeesViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> employees;
        private IEmployeeRepository repository;
        private Employee selectedEmployee;
        private IAccessRights accessRights;

        public event Action<Employee> NewEmployeeAdded;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(selectedEmployee));
            }
        }

        public RelayCommand AddNewEmployeeCommand { get; private set; }
        public RelayCommand OpenEmployeeInfoCommand { get; private set; }
        public RelayCommand ReloadCommand { get; private set; }

        public EmployeesViewModel(IAccessRights accessRights)
        {
            repository = new EmployeeRepository(new DBContext());

            ReloadCommand = new RelayCommand(LoadEmployees);
            AddNewEmployeeCommand = new RelayCommand(AddNewEmployee);

            this.accessRights = accessRights;
            LoadEmployees();
        }

        private void LoadEmployees(object obj = null)
        {
            List<Employee> loadedEmployees = repository.GetEmployees();
            Employees = new ObservableCollection<Employee>(loadedEmployees);
        }

        private void AddNewEmployee(object obj)
        {
            OnNewEmployeeAdded(new Employee());
        }

        private void OnNewEmployeeAdded(Employee employee)
        {
            NewEmployeeAdded?.Invoke(employee);
        }
    }
}
