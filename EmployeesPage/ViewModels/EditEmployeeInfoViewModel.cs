using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonClasses;
using Employees;
using MaterialDesignThemes.Wpf;

namespace EmployeesPage
{
    public class EditEmployeeInfoViewModel : ViewModelBase
    {
        private DBContext DBContext;
        private ISpecialtyRepository specialtyRepository;
        private IEduInstitutionsRepository eduInstitutionsRepository;
        private IEduDocumentTypesRepository eduDocumentTypesRepository;
        private IDivisionsRepository divisionsRepository;
        private IPositionsRepository positionsRepository;
        private IOrganizationNamesRepository organizationNamesRepository;
        private IEmployeeRepository employeeRepository;

        private Passport selectedPassport;
        private EduDocument selectedEduDocument;
        private Workplace selectedWorkplace;
        private Specialty selectedSpecialty;
        private EduInstitution selectedEduInstitution;
        private EduDocumentType selectedEduDocumentType;
        private Division selectedDivision;
        private Position selectedPosition;
        private OrganizationName selectedOrganizationName;

        private string gender;
        private string academicDegree;
        private string academicTitle;

        private RelayCommand addPassportCommand;
        private RelayCommand addEduDocumentCommand;
        private RelayCommand addWorkplaceCommand;

        private RelayCommand deletePassportCommand;
        private RelayCommand deleteEduDocumentCommand;
        private RelayCommand deleteWorkplaceCommand;

        private RelayCommand savePassportCommand;
        private RelayCommand saveEduDocumentCommand;
        private RelayCommand saveWorkplaceCommand;

        public ObservableCollection<Passport> Passports { get; set; }
        public ObservableCollection<EduDocument> EduDocuments { get; set; }
        public ObservableCollection<Workplace> Workplaces { get; set; }

        public ObservableCollection<Specialty> Specialties { get; set; }
        public ObservableCollection<EduInstitution> EduInstitutions { get; set; }
        public ObservableCollection<EduDocumentType> EduDocumentTypes { get; set; }
        public ObservableCollection<Division> Divisions { get; set; }
        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<OrganizationName> OrganizationNames { get; set; }

        public ObservableCollection<string> Genders { get; set; }
        public ObservableCollection<string> AcademicDegrees { get; set; }
        public ObservableCollection<string> AcademicTitles { get; set; }

        public Employee Employee { get; set; }

        #region commands
        public RelayCommand AddPassportCommand
        {
            get => addPassportCommand ??= new RelayCommand(_ => Passports.Insert(0, new Passport(Employee.Id)));
        }

        public RelayCommand AddEduDocumentCommand
        {
            get => addEduDocumentCommand ??= new RelayCommand(_ => EduDocuments.Insert(0, new EduDocument(Employee.Id)));
        }

        public RelayCommand AddWorkplaceCommand
        {
            get => addWorkplaceCommand ??= new RelayCommand(_ => Workplaces.Insert(0, new Workplace(Employee.Id)));
        }

        public RelayCommand DeletePassportCommand
        {
            get => deletePassportCommand ??= new RelayCommand(DeletePassport, (obj) => SelectedPassport != null);
        }

        private void DeletePassport(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить паспорт?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                employeeRepository.DeletePassport((long)SelectedPassport.Id);
                Passports.Remove(SelectedPassport);
            }
        }

        public RelayCommand DeleteEduDocumentCommand
        {
            get => deleteEduDocumentCommand ??= new RelayCommand(DeleteEduDocument, (obj) => SelectedEduDocument != null);
        }

        private void DeleteEduDocument(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить документ об образовании?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                EduDocuments.Remove(SelectedEduDocument);
                // TODO: сохранить данные в БД
            }
        }

        public RelayCommand DeleteWorkplaceCommand
        {
            get => deleteWorkplaceCommand ??= new RelayCommand(DeleteWorkplace, (obj) => SelectedWorkplace != null);
        }

        private void DeleteWorkplace(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить информацию о месте работы?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Workplaces.Remove(SelectedWorkplace);
            }
        }

        public RelayCommand SavePassportCommand
        {
            get => savePassportCommand ??= new RelayCommand(SavePassport, (obj) => SelectedPassport != null);
        }

        public void SavePassport(object obj)
        {
            employeeRepository.UpdatePassport(SelectedPassport);
            MessageBox.Show("Информация о паспорте сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public RelayCommand SaveEduDocumentCommand
        {
            get => saveEduDocumentCommand ??= new RelayCommand(SaveEduDocument, (obj) => SelectedEduDocument != null);
        }

        public void SaveEduDocument(object obj)
        {
            MessageBox.Show("Информация о документе об образовании сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public RelayCommand SaveWorkplaceCommand
        {
            get => saveWorkplaceCommand ??= new RelayCommand(SaveWorkplace, (obj) => SelectedWorkplace != null);
        }

        public void SaveWorkplace(object obj)
        {
            MessageBox.Show("Информация о месте работы сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion

        #region selected elements
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
                SelectedSpecialty = Specialties.FirstOrDefault(spec => spec.Id == value.SpecialtyId);
                SelectedEduInstitution = EduInstitutions.FirstOrDefault(i => i.Id == value.EduInstitutionId);
                SelectedEduDocumentType = EduDocumentTypes.FirstOrDefault(i => i.Id == value.EduDocumentTypeId);
                OnPropertyChanged(nameof(SelectedEduDocument));
            }
        }

        public Workplace SelectedWorkplace
        {
            get => selectedWorkplace;
            set
            {
                selectedWorkplace = value;
                SelectedDivision = Divisions.FirstOrDefault(i => i.Id == value.DivisionId);
                SelectedPosition = Positions.FirstOrDefault(i => i.Id == value.PositionId);
                SelectedOrganizationName = OrganizationNames.FirstOrDefault(i => i.Id == value.OrganizationId);
                OnPropertyChanged(nameof(SelectedWorkplace));
            }
        }
        
        public Specialty SelectedSpecialty
        {
            get => selectedSpecialty;
            set
            {
                selectedSpecialty = value;
                SelectedEduDocument.SpecialtyId = value.Id;
                OnPropertyChanged(nameof(SelectedSpecialty));
            }
        }

        public EduInstitution SelectedEduInstitution
        {
            get => selectedEduInstitution;
            set
            {
                selectedEduInstitution = value;
                SelectedEduDocument.EduInstitutionId = value.Id;
                OnPropertyChanged(nameof(SelectedEduInstitution));
            }
        }

        public EduDocumentType SelectedEduDocumentType
        {
            get => selectedEduDocumentType;
            set
            {
                selectedEduDocumentType = value;
                SelectedEduDocument.EduDocumentTypeId = value.Id;
                OnPropertyChanged(nameof(SelectedEduDocumentType));
            }
        }

        public Division SelectedDivision
        {
            get => selectedDivision;
            set
            {
                selectedDivision = value;
                SelectedWorkplace.DivisionId = value.Id;
                OnPropertyChanged(nameof(SelectedDivision));
            }
        }

        public Position SelectedPosition
        {
            get => selectedPosition;
            set
            {
                selectedPosition = value;
                SelectedWorkplace.PositionId = value.Id;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }

        public OrganizationName SelectedOrganizationName
        {
            get => selectedOrganizationName;
            set
            {
                selectedOrganizationName = value;
                SelectedWorkplace.OrganizationId = value.Id;
                OnPropertyChanged(nameof(SelectedOrganizationName));
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
        #endregion

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
            eduInstitutionsRepository = new EduInstitutionsRepository(DBContext);
            eduDocumentTypesRepository = new EduDocumentTypesRepository(DBContext);
            divisionsRepository = new DivisionsRepository(DBContext);
            positionsRepository = new PositionsRepository(DBContext);
            organizationNamesRepository = new OrganizationNamesRepository(DBContext);
            employeeRepository = new EmployeeRepository(DBContext);

            Specialties = new ObservableCollection<Specialty>(specialtyRepository.GetSpecialties());
            EduInstitutions = new ObservableCollection<EduInstitution>(eduInstitutionsRepository.GetEduInstitutions());
            EduDocumentTypes = new ObservableCollection<EduDocumentType>(eduDocumentTypesRepository.GetEduDocumentTypes());
            Divisions = new ObservableCollection<Division>(divisionsRepository.GetDivisions());
            Positions = new ObservableCollection<Position>(positionsRepository.GetPositions());
            OrganizationNames = new ObservableCollection<OrganizationName>(organizationNamesRepository.GetOrganizationNames());
        }
    }
}
