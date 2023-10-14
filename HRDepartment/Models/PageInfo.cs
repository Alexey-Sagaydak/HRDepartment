using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRDepartment
{
    public class PageInfo
    {
        public PageInfo(string title, Page page, AccessRights accessRights)
        {
            Title = title;
            Page = page;
            AccessRights = accessRights;
        }

        public string Title { get; set; }
        public Page Page { get; set; }
        public AccessRights AccessRights { get; set; }
    }
}
