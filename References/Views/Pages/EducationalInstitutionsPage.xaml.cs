﻿using CommonClasses;
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
    /// Логика взаимодействия для EducationalInstitutionsPage.xaml
    /// </summary>
    public partial class EducationalInstitutionsPage : Page
    {
        public IAccessRights accessRights;

        public EducationalInstitutionsPage()
        {
            InitializeComponent();
            accessRights = DataStore.AccessRightsData;
        }
    }
}
