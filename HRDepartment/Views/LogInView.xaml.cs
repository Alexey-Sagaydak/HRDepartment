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

namespace HRDepartment
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            DataContext = new LogInViewModel();

            // DELELE LATER
            using (var dbContext = new DBContext())
            {
                var repository = new SpecialtiesRepository(dbContext);

                // Пример использования репозитория:
                var specialty = repository.GetSpecialty(5);
                Console.WriteLine($"{specialty.id} {specialty.name}");
            }
        }
    }
}
