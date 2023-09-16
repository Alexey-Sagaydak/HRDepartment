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

            //PasswordHash passwordHash = new PasswordHash("3yYQv8xx5MjR63RFwWxLxaXR");
            //Console.WriteLine(passwordHash.HashPassword("admin"));
            // DELELE LATER
            //using (var dbContext = new DBContext())
            //{
            //    var repository = new SpecialtiesRepository(dbContext);

            //    // Пример использования репозитория:
            //    var specialty = repository.GetSpecialty(5);
            //    Console.WriteLine($"{specialty.Id} {specialty.Name}");
            //}
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((LogInViewModel)DataContext).Password = PasswordBox.Password;
            }
        }
    }
}
