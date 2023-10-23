using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Text.RegularExpressions;
using CommonClasses;

namespace HRDepartment
{
    public class LogInViewModel : ViewModelBase
    {
        private string email;
        private string password;

        private IAuthenticatorRepository authenticatorRepository;
        private readonly INavigationService navigationService;

        private RelayCommand enterCommand;

        public LogInViewModel()
        {
            email = "admin@a.aa";
            password = "admin";
            //email = string.Empty;
            //password = string.Empty;
            authenticatorRepository = new AuthenticatorRepository(new DBContext());
            navigationService = new NavigationService(Application.Current.MainWindow);
        }

        public RelayCommand EnterCommand
        {
            get
            {
                return enterCommand ??= new RelayCommand(FindEmployee, IsValidLogInData);
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public bool IsValidLogInData(object email)
        {
            string emailPattern = @"^[a-zA-Zа-яА-Я0-9._%+-]+@[a-zA-Zа-яА-Я0-9.-]+\.[a-zA-Zа-яА-Я]{2,}$";
            return Regex.IsMatch(this.email, emailPattern) && password != "";
        }

        public void FindEmployee(object employee)
        {
            int id = authenticatorRepository.FindEmployee(Email, Password);

            if (id == 0)
            {
                MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                navigationService.OpenMainWindow(id);
                navigationService.CloseCurrentWindow();
            }
        }
    }
}
