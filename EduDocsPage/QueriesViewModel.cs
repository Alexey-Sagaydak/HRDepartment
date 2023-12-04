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
        private RelayCommand createQuery3DocumentCommand;
        private DocumentCreator creator;

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

        public RelayCommand CreateQuery3DocumentCommand
        {
            get => createQuery3DocumentCommand ??= new RelayCommand(CreateQuery3Document);
        }

        private void CreateQuery3Document(object obj)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                creator.Query3Document(Employees, filePath);
            }
        }

        public QueriesViewModel(DBContext dBContext)
        {
            employeeRepository = new EmployeeRepository(dBContext);
            Employees = new ObservableCollection<Person>();
            creator = new DocumentCreator();
        }
    }
}
