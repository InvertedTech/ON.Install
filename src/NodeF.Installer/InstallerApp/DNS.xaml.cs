﻿using NodeF.Installer.Models;
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

namespace InstallerApp
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class DNS : Page
    {
        public DNSModel MyModel { get; set; }

        public DNS()
        {
            MyModel = MainWindow.MainModel.DNS;

            InitializeComponent();

            DataContext = MyModel;
        }
    }
}