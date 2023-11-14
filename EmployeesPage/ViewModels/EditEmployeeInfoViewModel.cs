using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;
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

            Specialties = new ObservableCollection<Specialty>(specialtyRepository.GetSpecialties());
            EduInstitutions = new ObservableCollection<EduInstitution>(eduInstitutionsRepository.GetEduInstitutions());
            EduDocumentTypes = new ObservableCollection<EduDocumentType>(eduDocumentTypesRepository.GetEduDocumentTypes());
            Divisions = new ObservableCollection<Division>(divisionsRepository.GetDivisions());
            Positions = new ObservableCollection<Position>(positionsRepository.GetPositions());
            OrganizationNames = new ObservableCollection<OrganizationName>(organizationNamesRepository.GetOrganizationNames());
        }
    }
}
