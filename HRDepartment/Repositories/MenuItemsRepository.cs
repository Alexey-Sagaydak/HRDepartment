using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

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
                    new MenuItemInfo(4, 0, "Справочники", null, null, 3),
                };
            }
            if (ParentId == 3)
            {
                menuItemsInfo = new List<MenuItemInfo>
                {
                    new MenuItemInfo(5, 3, "Отчеты по сотрудникам", "Documents.dll", "Documents.PassportsPage", 0),
                    new MenuItemInfo(6, 3, "Документы об образовании", "Documents.dll", "Documents.EduDocsPage", 1)
                };
            }
            if (ParentId == 4)
            {
                menuItemsInfo = new List<MenuItemInfo>
                {
                    new MenuItemInfo(7, 4, "Подразделения", "References.dll", "References.DivisionsPage", 0),
                    new MenuItemInfo(8, 4, "Адреса", "References.dll", "References.AddressesPage", 1),
                    new MenuItemInfo(9, 4, "Должности", "References.dll", "References.PositionsPage", 2),
                    new MenuItemInfo(10, 4, "Дополнительно", null, null, 3)
                };
            }
            if (ParentId == 10)
            {
                menuItemsInfo = new List<MenuItemInfo>
                {
                    new MenuItemInfo(11, 10, "Специальности", "References.dll", "References.SpecialtiesPage", 0),
                    new MenuItemInfo(12, 10, "Образовательные организации", "References.dll", "References.EducationalInstitutionsPage", 1),
                    new MenuItemInfo(13, 10, "Названия организаций", "References.dll", "References.OrganizationsNamesPage", 2),
                    new MenuItemInfo(14, 10, "Типы приказов", "References.dll", "References.OrdersTypesPage", 3),
                };
            }
            return menuItemsInfo;
        }

        public AccessRights GetAccessRights(int userId, int menuItemId)
        {
            AccessRights accessRights = new AccessRights(userId, menuItemId, true, true, true, true);
            return accessRights;
        }
    }
}
