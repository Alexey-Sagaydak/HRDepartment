using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommonClasses;

namespace HRDepartment
{
    public class PageInfo
    {
        public PageInfo(string title, AccessRights accessRights, Type pageType)
        {
            Title = title;
            AccessRights = accessRights;
            PageType = pageType;
        }

        public string Title { get; set; }
        public AccessRights AccessRights { get; set; }
        public Type PageType { get; set; }
    }
}
