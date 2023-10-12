using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    public class MenuItemViewModel : ViewModelBase
    {
        private readonly RelayCommand _command;
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
        public bool AvailabilityStatus { get; set; }
        public PageInfo CommandParameter { get; set; }
        public Action<PageInfo> Func {get; set;}
        public string Header { get; set; }

        public MenuItemViewModel(string header, Action<PageInfo> func, PageInfo commandParameter, bool availabilityStatus = true)
        {
            Header = header;
            AvailabilityStatus = availabilityStatus;
            Func = func;
            CommandParameter = commandParameter;
        }

        public RelayCommand Command
        {
            get
            {
                return _command ?? new RelayCommand(
                    _execute => Func(CommandParameter),
                    _canExecute => true
                );
            }
        }
    }
}
