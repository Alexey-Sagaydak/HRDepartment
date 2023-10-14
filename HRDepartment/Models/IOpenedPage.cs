using System.Windows.Controls;

namespace HRDepartment
{
    public interface IOpenedPage
    {
        AccessRights AccessRights { get; set; }
        Page PageInstance { get; set; }
        string Title { get; set; }
    }
}