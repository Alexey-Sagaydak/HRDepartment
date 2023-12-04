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
        private RelayCommand query1Command;
        private RelayCommand createQuery1DocumentCommand;
        private RelayCommand query2Command;
        private RelayCommand createQuery2DocumentCommand;
        private RelayCommand query3Command;
        private RelayCommand createQuery3DocumentCommand;
        private DocumentCreator creator;

        public ObservableCollection<PersonWithHours> EmployeesQ1 { get; set;}
        public ObservableCollection<Person> EmployeesQ2 { get; set;}
        public ObservableCollection<Person> EmployeesQ3 { get; set;}

        public RelayCommand Query1Command
        {
            get => query1Command ??= new RelayCommand(Query1);
        }

        private void Query1(object obj)
        {
            EmployeesQ1.Clear();

            var newEmployees = employeeRepository.GetCurrentWorkExperience();

            foreach (var employee in newEmployees)
            {
                EmployeesQ1.Add(employee);
            }
        }

        public RelayCommand Query2Command
        {
            get => query2Command ??= new RelayCommand(Query2);
        }

        private void Query2(object obj)
        {
            EmployeesQ2.Clear();

            var newEmployees = employeeRepository.GetDecemberVacationDetails();

            foreach (var employee in newEmployees)
            {
                EmployeesQ2.Add(employee);
            }
        }

        public RelayCommand Query3Command
        {
            get => query3Command ??= new RelayCommand(Query3);
        }

        private void Query3(object obj)
        {
            EmployeesQ3.Clear();

            var newEmployees = employeeRepository.GetEmployeesWithoutQualificationIncreaseLastYearOrNoHigherEducation();

            foreach (var employee in newEmployees)
            {
                EmployeesQ3.Add(employee);
            }
        }

        public RelayCommand CreateQuery1DocumentCommand
        {
            get => createQuery1DocumentCommand ??= new RelayCommand(CreateQuery1Document, _ => EmployeesQ1.Count() > 0);
        }

        private void CreateQuery1Document(object obj)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                creator.Query1Document(EmployeesQ1, filePath);
            }
        }

        public RelayCommand CreateQuery2DocumentCommand
        {
            get => createQuery2DocumentCommand ??= new RelayCommand(CreateQuery2Document, _ => EmployeesQ2.Count() > 0);
        }

        private void CreateQuery2Document(object obj)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                creator.Query2Document(EmployeesQ2, filePath);
            }
        }

        public RelayCommand CreateQuery3DocumentCommand
        {
            get => createQuery3DocumentCommand ??= new RelayCommand(CreateQuery3Document, _ => EmployeesQ3.Count() > 0);
        }

        private void CreateQuery3Document(object obj)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                creator.Query3Document(EmployeesQ3, filePath);
            }
        }

        public QueriesViewModel(DBContext dBContext)
        {
            employeeRepository = new EmployeeRepository(dBContext);
            EmployeesQ1 = new ObservableCollection<PersonWithHours>();
            EmployeesQ2 = new ObservableCollection<Person>();
            EmployeesQ3 = new ObservableCollection<Person>();
            creator = new DocumentCreator();
        }
    }
}
