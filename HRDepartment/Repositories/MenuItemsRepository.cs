using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment
{
    class MenuItemsRepository : Repository<MenuItemInfo>, IMenuItemsRepository
    {
        private DBContext DBContext => Context as DBContext;
        public MenuItemsRepository(DBContext dBContext) : base(dBContext) { }
        public List<MenuItemInfo> GetMenuItemsInfo(int ParentId)
        {
            List<MenuItemInfo> menuItemsInfo = new List<MenuItemInfo>
            {
                new MenuItemInfo(1, 0, "Приказы", "OrdersPage.dll", "Orders.OrdersPage", 0)
            };
            return menuItemsInfo;
        }
    }
}
