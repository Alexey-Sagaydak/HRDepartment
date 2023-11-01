using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

namespace EmployeesPage
{
    public class EditEmployeeInfoViewModel
    {
        private Employee employee;
        public EditEmployeeInfoViewModel(Employee employee)
        {
            this.employee = employee;
        }
    }
}
