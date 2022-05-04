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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public ProductSelectionModel MyModel { get; set; }

        public Products()
        {
            MyModel = MainWindow.MainModel.ProductSelection;

            InitializeComponent();

            DataContext = MyModel;

            Load();
        }

        private void Load()
        {
            cbHomepage.SelectedIndex = (int)MyModel.Homepage;
        }

        private void cbHomepage_Changed(object sender, SelectionChangedEventArgs e)
        {
            MyModel.Homepage = (ProductSelectionModel.HomepageProducts)cbHomepage.SelectedIndex;
        }
    }
}
