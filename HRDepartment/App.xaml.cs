using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Resources;

namespace HRDepartment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ResourceDictionary newResourceDictionary = new ResourceDictionary();

            // TODO: сделать здесь выбор локализации
            Uri resourceUri = new Uri("pack://application:,,,/HRDepartment;component/Resources/Localization-ru-RU.xaml");

            using (var stream = Application.GetResourceStream(resourceUri).Stream)
            {
                newResourceDictionary = (ResourceDictionary)XamlReader.Load(stream);
            }

            Current.Resources.MergedDictionaries.Add(newResourceDictionary);
        }
    }
}
