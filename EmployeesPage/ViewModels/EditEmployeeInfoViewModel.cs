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
        private IAccessRights accessRights;

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
        private RelayCommand deleteEmployeeCommand;

        private RelayCommand savePassportCommand;
        private RelayCommand saveEduDocumentCommand;
        private RelayCommand saveWorkplaceCommand;
        private RelayCommand saveMainDataCommand;

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
            get => addPassportCommand ??= new RelayCommand(AddPassport, _ => accessRights.Write && Employee.Id != null);
        }

        private void AddPassport(object obj)
        {
            Passports.Insert(0, new Passport(Employee.Id));
            SelectedPassport = Passports[0];
        }

        public RelayCommand AddEduDocumentCommand
        {
            get => addEduDocumentCommand ??= new RelayCommand(AddEduDocument, _ => accessRights.Write && Employee.Id != null);
        }

        private void AddEduDocument(object obj)
        {
            EduDocuments.Insert(0, new EduDocument(Employee.Id));
            SelectedEduDocument = EduDocuments[0];
        }

        public RelayCommand AddWorkplaceCommand
        {
            get => addWorkplaceCommand ??= new RelayCommand(AddWorkplace, _ => accessRights.Write && Employee.Id != null);
        }

        private void AddWorkplace(object obj)
        {
            Workplaces.Insert(0, new Workplace(Employee.Id));
            SelectedWorkplace = Workplaces[0];
        }

        public RelayCommand DeletePassportCommand
        {
            get => deletePassportCommand ??= new RelayCommand(DeletePassport, (obj) => SelectedPassport != null && SelectedPassport?.Id != null);
        }

        private void DeletePassport(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить паспорт?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                employeeRepository.DeletePassport((long)SelectedPassport.Id);
                Passports.Remove(SelectedPassport);
                OnPropertyChanged(nameof(Passports));
            }
        }

        public RelayCommand DeleteEduDocumentCommand
        {
            get => deleteEduDocumentCommand ??= new RelayCommand(DeleteEduDocument, (obj) => SelectedEduDocument != null && SelectedEduDocument?.Id != null);
        }

        private void DeleteEduDocument(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить документ об образовании?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                employeeRepository.DeleteEduDocument((long)SelectedEduDocument.Id);
                EduDocuments.Remove(SelectedEduDocument);
            }
        }

        public RelayCommand DeleteWorkplaceCommand
        {
            get => deleteWorkplaceCommand ??= new RelayCommand(DeleteWorkplace, (obj) => SelectedWorkplace != null && SelectedWorkplace?.Id != null);
        }

        private void DeleteWorkplace(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить информацию о месте работы?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                employeeRepository.DeleteWorkplace((long)SelectedWorkplace.Id);
                Workplaces.Remove(SelectedWorkplace);
            }
        }

        public RelayCommand DeleteEmployeeCommand
        {
            get => deleteEmployeeCommand ??= new RelayCommand(DeleteEmployee, (obj) => accessRights.Delete && Employee.Id != null);
        }

        private void DeleteEmployee(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить информацию о сотруднике?\nЭтот действие необратимо!", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                if (Passports.Count != 0 && MessageBox.Show("Удалить данные паспортов?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (Passport passport in Passports)
                    {
                        if (passport.Id != null)
                            employeeRepository.DeletePassport((long)passport.Id);
                    }
                    Passports.Clear();
                    SelectedPassport = new Passport(Employee.Id);
                    OnPropertyChanged(nameof(Passports));
                }

                if (EduDocuments.Count != 0 && MessageBox.Show("Удалить данные о документах об образовании?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (EduDocument eduDocument in EduDocuments)
                    {
                        if (eduDocument.Id != null)
                            employeeRepository.DeleteEduDocument((long)eduDocument.Id);
                    }
                    EduDocuments.Clear();
                    SelectedEduDocument = new EduDocument(Employee.Id);
                }

                if (Workplaces.Count != 0 && MessageBox.Show("Удалить данные о местах работы?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (Workplace workplace in Workplaces)
                    {
                        if (workplace.Id != null)
                            employeeRepository.DeleteWorkplace((long)workplace.Id);
                    }
                    Workplaces.Clear();
                    SelectedWorkplace = new Workplace(Employee.Id);
                }

                if (MessageBox.Show("Удалить личное дело сотрудника?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    employeeRepository.DeleteEmployee((long)Employee.Id);
                    Employee = new Employee();
                    OnPropertyChanged(nameof(Employee));
                }

                MessageBox.Show("Данные о работнике были успешно удалены из базы данных.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public RelayCommand SavePassportCommand
        {
            get => savePassportCommand ??= new RelayCommand(SavePassport, (obj) => SelectedPassport != null);
        }

        public void SavePassport(object obj)
        {
            try
            {
                employeeRepository.UpdatePassport(SelectedPassport);
                MessageBox.Show("Информация о паспорте сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Не удалось сохранить данные. Проверьте, что все обязательные поля заполнены.\n\nПоказать текст ошибки?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    MessageBox.Show($"{ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public RelayCommand SaveEduDocumentCommand
        {
            get => saveEduDocumentCommand ??= new RelayCommand(SaveEduDocument, (obj) => SelectedEduDocument != null);
        }

        public void SaveEduDocument(object obj)
        {
            try
            {
                SelectedEduDocument.EduDocumentTypeId = SelectedEduDocumentType.Id;
                SelectedEduDocument.EduInstitutionId = SelectedEduInstitution.Id;
                SelectedEduDocument.SpecialtyId = SelectedSpecialty.Id;

                employeeRepository.UpdateEduDocument(SelectedEduDocument);
                MessageBox.Show("Информация о документе об образовании сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Не удалось сохранить данные. Проверьте, что все обязательные поля заполнены.\n\nПоказать текст ошибки?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    MessageBox.Show($"{ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        public RelayCommand SaveWorkplaceCommand
        {
            get => saveWorkplaceCommand ??= new RelayCommand(SaveWorkplace, (obj) => SelectedWorkplace != null);
        }

        public void SaveWorkplace(object obj)
        {
            try
            {
                SelectedWorkplace.Order.EmployeeId = Employee.Id;
                SelectedWorkplace.EmployeeId = Employee.Id;
                SelectedWorkplace.OrganizationId = SelectedOrganizationName.Id;
                SelectedWorkplace.PositionId = SelectedPosition.Id;
                SelectedWorkplace.DivisionId = SelectedDivision.Id;

                employeeRepository.UpdateWorkplace(SelectedWorkplace);
                MessageBox.Show("Информация о месте работы сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Не удалось сохранить данные. Проверьте, что все обязательные поля заполнены.\n\nПоказать текст ошибки?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    MessageBox.Show($"{ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        public RelayCommand SaveMainDataCommand
        {
            get => saveMainDataCommand ??= new RelayCommand(SaveMainData);
        }

        public void SaveMainData(object obj)
        {

            try
            {
                employeeRepository.SaveMainData(Employee);
                MessageBox.Show("Общая информация о работнике сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Не удалось сохранить данные. Проверьте, что все обязательные поля заполнены.\n\nПоказать текст ошибки?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    MessageBox.Show($"{ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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

        public EditEmployeeInfoViewModel(Employee employee, IAccessRights accessRights)
        {
            DBContext = new DBContext();

            this.accessRights = accessRights;
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
