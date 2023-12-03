using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonClasses;
using Employees;

namespace Documents
{
    public class QueriesViewModel : ViewModelBase
    {
        private IEmployeeRepository employeeRepository;
        private RelayCommand query3Command;

        public ObservableCollection<Person> Employees { get; set;}

        public RelayCommand Query3Command
        {
            get => query3Command ??= new RelayCommand(Query3);
        }

        private void Query3(object obj)
        {
            Employees.Clear();

            var newEmployees = employeeRepository.GetEmployeesWithoutQualificationIncreaseLastYearOrNoHigherEducation();

            foreach (var employee in newEmployees)
            {
                Employees.Add(employee);
            }
        }

        public QueriesViewModel(DBContext dBContext)
        {
            employeeRepository = new EmployeeRepository(dBContext);
            Employees = new ObservableCollection<Person>();
        }
    }
}
