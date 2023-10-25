using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CommonClasses;


namespace References
{
    public class SpecialtiesViewModel : ViewModelBase
    {
        private ObservableCollection<Specialty> specialties;
        private ISpecialtyRepository repository;
        private bool IsUnsaved;
        private string newItem;
        private bool canAddNewItem;
        private Specialty selectedSpecialty;

        public Specialty SelectedSpecialty
        {
            get { return selectedSpecialty; }
            set
            {
                selectedSpecialty = value;
                OnPropertyChanged(nameof(SelectedSpecialty));
            }
        }

        public bool CanAddNewItem
        {
            get => canAddNewItem;
            set
            {
                canAddNewItem = value;
                OnPropertyChanged("CanAddNewItem");
            }
        }

        public ObservableCollection<Specialty> Specialties
        {
            get { return specialties; }
            set
            {
                specialties = value;
                OnPropertyChanged(nameof(Specialties));
            }
        }

        public string NewItem
        {
            get => newItem;
            set
            {
                newItem = value;
                CanAddNewItemCheck();
                OnPropertyChanged("NewItem");
            }
        }

        public RelayCommand AddSpecialtyCommand { get; private set; }
        public RelayCommand DeleteSpecialtyCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand ReloadCommand { get; private set; }

        public SpecialtiesViewModel()
        {
            repository = new SpecialtyRepository(new DBContext());
            IsUnsaved = false;
            NewItem = string.Empty;
            CanAddNewItem = false;

            AddSpecialtyCommand = new RelayCommand(AddSpecialty);
            DeleteSpecialtyCommand = new RelayCommand(DeleteSpecialty, CanDeleteSelectedSpecialty);
            SaveCommand = new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);
            ReloadCommand = new RelayCommand(LoadSpecialties);

            LoadSpecialties();
        }

        private bool CanSaveCommandExecute(object obj)
        {
            return IsUnsaved;
        }

        private bool CanDeleteSelectedSpecialty(object obj)
        {
            return SelectedSpecialty != null;
        }

        public void CanAddNewItemCheck()
        {
            if (NewItem != "")
            {
                foreach (var item in Specialties)
                {
                    if (item.Name == NewItem)
                    {
                        CanAddNewItem = false;
                        return;
                    }
                }
                CanAddNewItem = true;
            }
            else
            {
                CanAddNewItem = false;
            }
        }

        private void SaveCommandExecute(object obj)
        {
            repository.SaveChanges();
            IsUnsaved = false;
        }

        private void LoadSpecialties(object obj = null)
        {
            List<Specialty> loadedSpecialties = repository.GetSpecialties();
            Specialties = new ObservableCollection<Specialty>(loadedSpecialties);
        }

        private void AddSpecialty(object obj)
        {
            IsUnsaved = true;
            Specialties.Add(repository.AddSpecialty(NewItem));
            NewItem = string.Empty;
        }

        private void DeleteSpecialty(object obj)
        {
            IsUnsaved = true;
            repository.DeleteSpecialty(SelectedSpecialty);
            foreach (var item in Specialties)
            {
                if (item.Id == SelectedSpecialty.Id)
                {
                    Specialties.Remove(item);
                    break;
                }
            }
            SelectedSpecialty = null;
        }
    }
}
