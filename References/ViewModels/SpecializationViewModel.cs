using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonClasses;


namespace References
{
    public class SpecializationViewModel : ViewModelBase
    {
        private ObservableCollection<Specialization> specializations;
        private Specialization selectedSpecialization;

        public ObservableCollection<Specialization> Specializations
        {
            get { return specializations; }
            set
            {
                specializations = value;
                OnPropertyChanged();
            }
        }

        public SpecializationViewModel()
        {
            Specializations = new ObservableCollection<Specialization>(GetSpecializationsFromDatabase());
        }

        private List<Specialization> GetSpecializationsFromDatabase()
        {
            // Здесь вам нужно реализовать код для получения специальностей из базы данных.
            // Верните список специальностей в форме List<Specialization>.
            List<Specialization> specializations = new List<Specialization>
        {
            new Specialization { Id = 1, Name = "Specialization 1" },
            new Specialization { Id = 2, Name = "Specialization 2" },
            // Добавьте остальные специальности
        };
            return specializations;
        }

        public Specialization SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set
            {
                selectedSpecialization = value;
                OnPropertyChanged();
            }
        }

        // Команда для добавления специальности
        public ICommand AddSpecializationCommand
        {
            get { return new RelayCommand(AddSpecialization, CanAddSpecialization); }
        }

        // Команда для удаления специальности
        public ICommand DeleteSpecializationCommand
        {
            get { return new RelayCommand(DeleteSpecialization, CanDeleteSpecialization); }
        }

        private void AddSpecialization(object parameter)
        {
            // Создайте новую специальность и добавьте её в коллекцию
            Specialization newSpecialization = new Specialization { Name = "New Specialization" };
            Specializations.Add(newSpecialization);
        }

        private bool CanAddSpecialization(object parameter)
        {
            return true; // Всегда разрешено добавление специальности
        }

        private void DeleteSpecialization(object parameter)
        {
            // Удалите выбранную специальность из коллекции
            if (SelectedSpecialization != null)
            {
                Specializations.Remove(SelectedSpecialization);
            }
        }

        private bool CanDeleteSpecialization(object parameter)
        {
            return SelectedSpecialization != null; // Разрешено удаление, если есть выбранная специальность
        }
    }
}
