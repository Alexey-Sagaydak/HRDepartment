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

            List<MenuItemInfo> menuItemsInfo = new List<MenuItemInfo>();
            if (ParentId == 0)
            {
                menuItemsInfo = new List<MenuItemInfo>
                {
                    new MenuItemInfo(1, 0, "Сотрудники", "EmployeesPage.dll", "Employees.EmployeesPage", 0),
                    new MenuItemInfo(2, 0, "Приказы", "OrdersPage.dll", "Orders.OrdersPage", 1),
                    new MenuItemInfo(3, 0, "Документы", null, null, 2),
                };
            }
            if (ParentId == 3)
            {
                menuItemsInfo = new List<MenuItemInfo>
                {
                    new MenuItemInfo(4, 3, "Паспорта", "PassportsPage.dll", "Passports.PassportsPage", 0)
                };
            }
                    
            return menuItemsInfo;
        }
    }
}
