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
        private DBContext DBContext;
        private ISpecialtyRepository specialtyRepository;
        private Passport selectedPassport;
        private EduDocument selectedEduDocument;
        private Workplace selectedWorkplace;
        private string gender;
        private string academicDegree;
        private string academicTitle;

        public ObservableCollection<Passport> Passports { get; set; }
        public ObservableCollection<EduDocument> EduDocuments { get; set; }
        public ObservableCollection<Workplace> Workplaces { get; set; }
        public ObservableCollection<Specialty> Specialties { get; set; }
        public ObservableCollection<string> Genders { get; set; }
        public ObservableCollection<string> AcademicDegrees { get; set; }
        public ObservableCollection<string> AcademicTitles { get; set; }

        public Employee Employee { get; set; }

        public Passport SelectedPassport
        {
            get => selectedPassport;
            set
            {
                selectedPassport = value;
                Gender = EnumHelper.GetDescription(value.Gender);
                OnPropertyChanged(nameof(SelectedPassport));
            }
        }

        public EduDocument SelectedEduDocument
        {
            get => selectedEduDocument;
            set
            {
                selectedEduDocument = value;
                OnPropertyChanged(nameof(SelectedEduDocument));
            }
        }

        public Workplace SelectedWorkplace
        {
            get => selectedWorkplace;
            set
            {
                selectedWorkplace = value;
                OnPropertyChanged(nameof(SelectedWorkplace));
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                selectedPassport.Gender = EnumHelper.GetEnumValueFromDescription<Gender>(value);
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string AcademicDegree
        {
            get => academicDegree;
            set
            {
                Employee.AcademicDegree = EnumHelper.GetEnumValueFromDescription<AcademicDegree>(value);
                academicDegree = value;
                OnPropertyChanged(nameof(AcademicDegree));
            }
        }

        public string AcademicTitle
        {
            get => academicTitle;
            set
            {
                Employee.AcademicTitle = EnumHelper.GetEnumValueFromDescription<AcademicTitle>(value);
                academicTitle = value;
                OnPropertyChanged(nameof(AcademicTitle));
            }
        }

        public EditEmployeeInfoViewModel(Employee employee)
        {
            DBContext = new DBContext();

            Employee = employee;

            AcademicDegree = EnumHelper.GetDescription(employee.AcademicDegree);
            AcademicTitle = EnumHelper.GetDescription(employee.AcademicTitle);

            Passports = new ObservableCollection<Passport>(Employee.Passports);
            EduDocuments = new ObservableCollection<EduDocument>(Employee.EduDocuments);
            Workplaces = new ObservableCollection<Workplace>(Employee.Workplaces);
            Genders = new ObservableCollection<string>(EnumHelper.GetDescriptions<Gender>());
            AcademicDegrees = new ObservableCollection<string>(EnumHelper.GetDescriptions<AcademicDegree>());
            AcademicTitles = new ObservableCollection<string>(EnumHelper.GetDescriptions<AcademicTitle>());

            specialtyRepository = new SpecialtyRepository(DBContext);
            
            foreach (var v in specialtyRepository.GetSpecialtiesLike("аб"))
            {
                Console.WriteLine(v.Name);
            }
        }
    }
}
