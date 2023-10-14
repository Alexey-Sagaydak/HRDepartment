using System.Windows.Controls;

namespace References
{
    public interface IOpenedPage
    {
        IAccessRights AccessRights { get; set; }
        Page PageInstance { get; set; }
        string Title { get; set; }
    }
}