using CommonClasses;
using System.Windows.Controls;

namespace HRDepartment
{
    public interface IOpenedPage
    {
        IAccessRights AccessRights { get; set; }
        Page PageInstance { get; set; }
        string Title { get; set; }
    }
}