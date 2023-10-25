using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SpecialtiesViewModel()
        {
            repository = new SpecialtyRepository(new DBContext());
            IsUnsaved = false;
            NewItem = string.Empty;
            CanAddNewItem = false;

            AddSpecialtyCommand = new RelayCommand(AddSpecialty);
            DeleteSpecialtyCommand = new RelayCommand(DeleteSpecialty);
            SaveCommand = new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);

            LoadSpecialties();
        }

        private bool CanSaveCommandExecute(object obj)
        {
            return IsUnsaved;
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

        private void LoadSpecialties()
        {
            List<Specialty> loadedSpecialties = repository.GetSpecialties();
            Specialties = new ObservableCollection<Specialty>(loadedSpecialties);
        }

        private void AddSpecialty(object obj)
        {
            IsUnsaved = true;
            Console.WriteLine(NewItem);
            // Обработка добавления специальности, добавьте здесь логику.
        }

        private void DeleteSpecialty(object obj)
        {
            IsUnsaved = true;
            // Обработка удаления специальности, добавьте здесь логику.
        }
    }
}
