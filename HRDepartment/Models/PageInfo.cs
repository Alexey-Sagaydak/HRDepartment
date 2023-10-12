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
        public PageInfo(string title, Page page)
        {
            Title = title;
            Page = page;
        }

        public string Title { get; set; }
        public Page Page { get; set; }
    }
}
