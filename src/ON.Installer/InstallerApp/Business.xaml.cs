using ON.Installer.Models;
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
    /// Interaction logic for Business.xaml
    /// </summary>
    public partial class Business : Page
    {
        public BusinessModel MyModel { get; set; }

        public Business()
        {
            MyModel = MainWindow.MainModel.Business;

            InitializeComponent();

            DataContext = MyModel;
        }
    }
}
