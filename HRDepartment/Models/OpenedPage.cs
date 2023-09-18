using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRDepartment
{
    public class OpenedPage
    {
        public string Title { get; set; }
        public Page PageInstance { get; set; }

        public OpenedPage(string title, Page page)
        {
            Title = title;
            PageInstance = page;
        }
    }
}
