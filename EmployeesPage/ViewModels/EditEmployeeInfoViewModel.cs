using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

namespace EmployeesPage
{
    public class EditEmployeeInfoViewModel : ViewModelBase
    {
        private Passport selectedPassport;
        private EduDocument selectedEduDocument;
        private Workplace selectedWorkplace;

        public ObservableCollection<Passport> Passports { get; set; }
        public ObservableCollection<EduDocument> EduDocuments { get; set; }
        public ObservableCollection<Workplace> Workplaces { get; set; }

        public Employee Employee { get; set; }

        public Passport SelectedPassport
        {
            get => selectedPassport;
            set
            {
                selectedPassport = value;
                OnPropertyChanged("SelectedPassport");
            }
        }

        public EduDocument SelectedEduDocument
        {
            get => selectedEduDocument;
            set
            {
                selectedEduDocument = value;
                OnPropertyChanged("SelectedEduDocument");
            }
        }

        public Workplace SelectedWorkplace
        {
            get => selectedWorkplace;
            set
            {
                selectedWorkplace = value;
                OnPropertyChanged("SelectedWorkplace");
            }
        }

        public EditEmployeeInfoViewModel(Employee employee)
        {
            Employee = employee;

            Passports = new ObservableCollection<Passport>(Employee.Passports);
            EduDocuments = new ObservableCollection<EduDocument>(Employee.EduDocuments);
            Workplaces = new ObservableCollection<Workplace>(Employee.Workplaces);
        }
    }
}
