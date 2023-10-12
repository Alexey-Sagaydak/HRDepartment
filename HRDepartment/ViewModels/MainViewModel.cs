using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.Reflection;
using Orders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;
using System.ComponentModel;

namespace HRDepartment
{
    public class MainViewModel : ViewModelBase
    {
        private int currentEmployeeID;
        private IMenuItemsRepository menuItemsRepository;

        public delegate void AddPageEventHandler(string title, Page page);
        public event AddPageEventHandler SomeEvent;

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public MainViewModel(int currentEmployeeID)
        {
            this.currentEmployeeID = currentEmployeeID;
            MenuItems = new ObservableCollection<MenuItemViewModel>();
            menuItemsRepository = new MenuItemsRepository(new DBContext());
            CreateMenu(MenuItems, 0);
            Console.WriteLine(MenuItems[0].Header);
        }

        private void CreateMenu(ObservableCollection<MenuItemViewModel> currentMenuItemsCollection, int ParentId)
        {
            List<MenuItemInfo> menuItemsInfo = menuItemsRepository.GetMenuItemsInfo(ParentId);

            foreach (MenuItemInfo menuItem in menuItemsInfo)
            {
                if (menuItem.DLLName == null && menuItem.ClassName == null)
                {
                    currentMenuItemsCollection.Add(new MenuItemViewModel(menuItem.Name, null, null));
                    var newCollection = new ObservableCollection<MenuItemViewModel>();
                    currentMenuItemsCollection.Last().MenuItems = newCollection;
                    CreateMenu(newCollection, menuItem.Id);
                }
                else
                {
                    currentMenuItemsCollection.Add(CreateMenuItem(menuItem));
                }
            }
        }

        private MenuItemViewModel CreateMenuItem(MenuItemInfo menuItemInfo)
        {
            MenuItemViewModel menuItemVM;
            Page page;
            Type type = null;
            try
            {
                Assembly assembly = Assembly.LoadFrom(menuItemInfo.DLLName);

                for (int i = 0; i < assembly.GetTypes().Length; i++)
                {
                    if (menuItemInfo.ClassName == assembly.GetTypes()[i].FullName)
                    {
                        type = assembly.GetTypes()[i];
                        break;
                    }
                }

                if (type != null)
                {
                    page = (Page)Activator.CreateInstance(type);
                    menuItemVM = new MenuItemViewModel(menuItemInfo.Name, RaiseAddPageEvent, new PageInfo(menuItemInfo.Name, page));
                    
                    return menuItemVM;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            return null;
        }

        private void RaiseAddPageEvent(object parameter)
        {
            PageInfo pageInfo = parameter as PageInfo;
            SomeEvent?.Invoke(pageInfo.Title, pageInfo.Page);
        }
    }
}
