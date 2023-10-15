using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRDepartment
{
    public class OpenedPage : IOpenedPage
    {
        public string Title { get; set; }
        public Page PageInstance { get; set; }
        public IAccessRights AccessRights { get; set; }

        public OpenedPage(string title, Page page, IAccessRights accessRights)
        {
            Title = title;
            PageInstance = page;
            AccessRights = accessRights;
        }
    }
}
