using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace References
{
    /// <summary>
    /// Логика взаимодействия для AddressesPage.xaml
    /// </summary>
    public partial class AddressesPage : Page
    {
        IAccessRights accessRights;
        string title;
        public AddressesPage()
        {
            InitializeComponent();
            IOpenedPage openedPage = Tag as IOpenedPage;
            if (openedPage != null )
            {
                accessRights = openedPage.AccessRights;
                title = openedPage.Title;
                Console.WriteLine(accessRights.Read);
                Console.WriteLine(accessRights.Wright);
                Console.WriteLine(accessRights.Edit);
                Console.WriteLine(accessRights.Delete);
            }
            Console.WriteLine("dfdfdf");
        }
    }
}
