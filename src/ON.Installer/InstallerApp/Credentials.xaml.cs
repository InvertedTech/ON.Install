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
    /// Interaction logic for Credentials.xaml
    /// </summary>
    public partial class Credentials : Page
    {
        public CredentialsModel MyModel { get; set; }

        public Credentials()
        {
            MyModel = MainWindow.MainModel.Credentials;

            InitializeComponent();

            DataContext = MyModel;
        }
    }
}
