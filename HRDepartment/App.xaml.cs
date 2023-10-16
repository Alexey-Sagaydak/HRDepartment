using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Resources;
using CommonClasses;

namespace HRDepartment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IAccessRights accessRightsData { get; set; }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ResourceDictionary newResourceDictionary = new ResourceDictionary();
            string filePath = @"Resources\Language.txt";
            string localizationString;
            Uri resourceUri;

            if (File.Exists(filePath))
            {
                localizationString = $"pack://application:,,,/HRDepartment;component/Resources/Localization-{File.ReadAllText(filePath)}.xaml";
                resourceUri = new Uri(localizationString);
            }
            else
            {
                throw new FileNotFoundException("Не найден файл со строкой подключения к БД", filePath);
            }

            using (var stream = GetResourceStream(resourceUri).Stream)
            {
                newResourceDictionary = (ResourceDictionary)XamlReader.Load(stream);
            }

            Current.Resources.MergedDictionaries.Add(newResourceDictionary);
        }
    }
}
