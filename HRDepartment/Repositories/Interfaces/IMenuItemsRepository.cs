using System.Collections.Generic;

namespace HRDepartment
{
    internal interface IMenuItemsRepository
    {
        List<MenuItemInfo> GetMenuItemsInfo(int ParentId);
        AccessRights GetAccessRights(int userId, int menuItemId);
    }
}