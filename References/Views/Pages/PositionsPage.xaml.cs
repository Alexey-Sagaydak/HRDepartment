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
    /// Логика взаимодействия для PositionsPage.xaml
    /// </summary>
    public partial class PositionsPage : Page
    {
        public IAccessRights accessRights;

        public PositionsPage()
        {
            InitializeComponent();
            accessRights = DataStore.AccessRightsData;
        }
    }
}