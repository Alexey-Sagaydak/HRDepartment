using System.Collections.Generic;
using CommonClasses;

namespace HRDepartment
{
    internal interface IMenuItemsRepository
    {
        List<MenuItemInfo> GetMenuItemsInfo(int ParentId);
        AccessRights GetAccessRights(int userId, int menuItemId);
    }
}